using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DonorCentar.Models;
using DonorCentar.Helper;
using DonorCentar.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.SignalR;
using DonorCentar.Hubs;

namespace DonorCentar.Controllers
{
    public class HomeController : Controller
    {
        private BazaPodataka db;
        private IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> hubContext, BazaPodataka _db)
        {
            db = _db;
            _logger = logger;
            _hubContext = hubContext;
        }

        public void SendMail(string from, string to, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("donorcentar@gmail.com", "rs1seminarski");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        public IActionResult Index()
        {
            return View(new HomeIndexVM
            {
                ZapamtiSifru = true
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ONama()
        {
            return View();
        }

        public ActionResult Registracija()
        {
            var model = new HomeRegistracijaVM
            {
                Grad = db.Grad.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Naziv
                }).ToList(),
                TipKorisnika = db.TipKorisnika.Where(t => t.Id != 4).Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tip
                }).ToList()
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Spasi(HomeRegistracijaVM korisnik)
        {
            if (!ModelState.IsValid)
            {
                if (korisnik.Sifra != korisnik.PonoviSifru)
                {
                    ModelState["korisnik.LoginPodaci.PonoviSifru"].Errors.Clear();
                    ModelState["korisnik.LoginPodaci.PonoviSifru"].Errors.Add("Šifre se ne poklapaju");
                }

                korisnik.Grad = db.Grad.Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Naziv
                }).ToList();

                korisnik.TipKorisnika = db.TipKorisnika.Where(t => t.Id != 4).Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Tip
                }).ToList();


                return View("Registracija", korisnik);
            }

            korisnik.Sifra = HashSifru(korisnik.Sifra);

            Korisnik k = new Korisnik
            {
                GradId = (int)korisnik.GradId,
                LicniPodaci = new LicniPodaci
                {
                    Adresa = korisnik.Adresa,
                    BrojTelefona = korisnik.BrojTelefona,
                    Email = korisnik.Email,
                    Naziv = korisnik.Naziv
                },
                LoginPodaci = new LoginPodaci
                {
                    KorisnickoIme = korisnik.KorisnickoIme,
                    Sifra = korisnik.Sifra
                },
                TipKorisnikaId = (int)korisnik.TipKorisnikaId
            };

            db.Korisnik.Add(k);
            db.SaveChanges();

            SendMail("donorcentar@gmail.com", korisnik.Email, "Registracija", "Zahvaljujemo se na vašoj registraciji. Sada ste dio zajednice koje spaja humane osobe sa organizacijama širom Bosne i Hercegovine. Uživajte.");

            if (korisnik.TipKorisnikaId == 1)
            {
                var donor = new Donor();
                donor.KorisnikId = k.Id;
                donor.DatumRegistracije = DateTime.Now;
                db.Donor.Add(donor);
                db.SaveChanges();
            } 
            else if (korisnik.TipKorisnikaId == 2)
            {
                var primalac = new Primalac();
                primalac.KorisnikId = k.Id;
                primalac.Verifikovan = false;
                primalac.DatumRegistracije = DateTime.Now;

                var obavijest = new Obavijest
                {
                    OdKorisnikId = k.Id,
                    TipKorisnikaId = 4,
                    TipObavijestiId = 1,
                    Vrijeme = DateTime.Now,
                    ZaKorisnikId = db.Korisnik.Where(k => k.TipKorisnikaId == 4).FirstOrDefault().Id
                };

                db.Obavijest.Add(obavijest);
                db.Primalac.Add(primalac);
                db.SaveChanges();

                _hubContext.Clients.All.SendAsync("ReceiveNotification", obavijest.ZaKorisnikId);

            }
            else
            {
                var partner = new Partner();
                partner.KorisnikId = k.Id;
                partner.DatumRegistracije = DateTime.Now;
                db.Partner.Add(partner);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public string HashSifru(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public ActionResult Prijava(HomeIndexVM input)
        {
            LoginPodaci login = db.LoginPodaci.SingleOrDefault(x => x.KorisnickoIme == input.KorisnickoIme && x.Sifra == HashSifru(input.Sifra));

            if (login == null)
            {
                ViewData["error_poruka"] = "Pogrešno korisničko ime ili šifra";
                return View("Index", input);
            }


            Korisnik korisnik = db.Korisnik.Where(k => k.LoginPodaciId == login.Id)
                .Include(k => k.LicniPodaci)
                .Include(k => k.Grad)
                .Include(k => k.TipKorisnika)
                .Include(k => k.LoginPodaci).Single();

            HttpContext.SetLogiraniKorisnik(korisnik);

            if (korisnik != null)
            {
                if(korisnik.TipKorisnikaId == 1)
                {
                    return RedirectToAction("Index", "Donor");
                }
                else if (korisnik.TipKorisnikaId == 2)
                {
                    return RedirectToAction("Index", "Primalac");

                }
                else if (korisnik.TipKorisnikaId == 3)
                {
                    return RedirectToAction("Index", "Partner");
                }
                else
                {
                    return RedirectToAction("Index", "Administrator");
                }
            } else
            {
                ViewData["error_poruka"] = "Nije pronađen korisnik.";
                return View("Index");
            }
        }

        public ActionResult Odjava()
        {
            return RedirectToAction("Index");
        }
    }
}
