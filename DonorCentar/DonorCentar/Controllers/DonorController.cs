using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Helper;
using DonorCentar.Hubs;
using DonorCentar.Models;
using DonorCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DonorCentar.Controllers
{
    public class DonorController : Controller
    {
        private BazaPodataka db;
        private IHubContext<NotificationHub> _hubContext;
        public DonorController(IHubContext<NotificationHub> hubContext, BazaPodataka _db)
        {
            _hubContext = hubContext;
            db = _db;
        }
        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            int donorId = db.Donor.Where(d => d.KorisnikId == k.Id).FirstOrDefault().Id;

            var korisnikViewModel = new KorisnikVM
            {
                Id = donorId,
                Naziv = k.LicniPodaci.Naziv,
                TipKorisnika = k.TipKorisnika.Tip,
                Adresa = k.LicniPodaci.Adresa,
                BrojTelefona = k.LicniPodaci.BrojTelefona,
                Email = k.LicniPodaci.Email,
                Grad = k.Grad.Naziv,
                PozitivniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 1),
                NeutralniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 2),
                NegativniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 3)
            };

            PostaviViewBag(k.Id, "Index");
            return View(korisnikViewModel);
        }

        public ActionResult Obavijesti()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ObavijestiVM model = new ObavijestiVM
            {
                rows = db.Obavijest.Where(d => d.ZaKorisnikId == k.Id).Select(o => new ObavijestiVM.Row
                {
                    ZaKorisnikId = o.ZaKorisnikId,
                    ObavijestId = o.ObavijestId,
                    Naziv = o.OdKorisnik.LicniPodaci.Naziv,
                    Obavijest = o.TipObavijesti.Obavijest,
                    Vrijeme = o.Vrijeme,
                    OdKorisnikId = o.OdKorisnikId,
                    TipKorisnikaId = o.TipKorisnikaId,
                    TipObavijestiId = o.TipObavijestiId
                }).ToList()
            };

            PostaviViewBag(k.Id, "Obavijesti");
            return View(model);
        }
        public ActionResult DodajDonaciju()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }
            /*PRILIKOM DODAVANJA DONACIJE -> DonorID = KorisnikID od donora*/

            PostaviViewBag(k.Id, "DodajDonaciju");
            return View();
        }

        public ActionResult PregledPotreba()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            DonorPregledPotrebaVM model = new DonorPregledPotrebaVM
            {
                rows = db.Donacija.Where(d => d.StatusId == 2).Select(d => new DonorPregledPotrebaVM.Row
                {
                    DonacijaId = d.DonacijaId,
                    LicniPodaciNaziv = d.Primalac.LicniPodaci.Naziv,
                    PrimalacId = (int)d.PrimalacId,
                    StatusId = d.StatusId,
                    StatusOpis = d.Status.Opis,
                    TipDonacije = d.TipDonacije.Tip
                }).ToList()
            };

            PostaviViewBag(k.Id, "PregledPotreba");
            return View(model);
        }

        public ActionResult DonacijeBezTransporta()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            PostaviViewBag(k.Id, "DonacijeBezTransporta");
            return View();
        }

        public ActionResult HistorijaDonacija()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            /*Ukoliko Donor nije ostavio dojam primaocu za zavrsenu donaciju,
              treba da postoji button "Ostavi dojam" */

            PostaviViewBag(k.Id, "HistorijaDonacija");
            return View();
        }

        public ActionResult OstaliKorisnici()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            PostaviViewBag(k.Id, "OstaliKorisnici");
            return View();
        }

        public ActionResult DetaljiDonacije(int donacijaId, int akcija)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija donacija = db.Donacija.Where(d => d.DonacijaId == donacijaId)
                .Include(d => d.Status)
                .Include(d => d.Primalac)
                .Include(d => d.Primalac.LicniPodaci)
                .Include(d => d.Primalac.Grad)
                .Include(d => d.TipDonacije)
                .FirstOrDefault();

            DonorDetaljiDonacijeVM model = new DonorDetaljiDonacijeVM
            {
                DonacijaId = donacijaId,
                JedinicaMjere = (JedinicaMjere)donacija.JedinicaMjere,
                Kolicina = donacija.Kolicina,
                Opis = donacija.Opis,
                StatusOpis = donacija.Status.Opis,
                TipDonacije = donacija.TipDonacije.Tip
            };

            if (donacija.Primalac != null)
            {
                model.PrimalacAdresa = donacija.Primalac.LicniPodaci.Adresa;
                model.PrimalacGrad = donacija.Primalac.Grad.Naziv;
                model.PrimalacLicniPodaciNaziv = donacija.Primalac.LicniPodaci.Naziv;
            } else
            {
                model.PrimalacAdresa = "Donacija je bez primaoca";
                model.PrimalacGrad = "";
                model.PrimalacLicniPodaciNaziv = "Donacija je bez primaoca";
            }

            if (akcija == 1)
            {
                PostaviViewBag(k.Id, "MojeAktivneDonacije");
            }
            else
            {
                PostaviViewBag(k.Id, "PregledPotreba");
            }

            ViewBag.Akcija = akcija;
            return View(model);
        }

        public ActionResult PrekiniDonaciju(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);

            Obavijest o = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 2,
                TipObavijestiId = 9,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.PrimalacId
            };

            d.PrimalacId = null;
            d.TransportId = null;
            d.StatusId = 1;
            db.Obavijest.Add(o);
            db.SaveChanges();

            _hubContext.Clients.All.SendAsync("ReceiveNotification", o.ZaKorisnikId);

            return RedirectToAction("MojeAktivneDonacije");
        }

        public ActionResult OdbijZahtjev(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);

            Obavijest o = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 2,
                TipObavijestiId = 7,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.PrimalacId
            };

            d.PrimalacId = null;
            d.TransportId = null;
            d.StatusId = 1;
            db.Obavijest.Add(o);
            db.SaveChanges();

            _hubContext.Clients.All.SendAsync("ReceiveNotification", o.ZaKorisnikId);

            return RedirectToAction("MojeAktivneDonacije");
        }

        public ActionResult MojeAktivneDonacije()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            var model = new DonorMojeAktivneDonacijeVM
            {
                rows = db.Donacija.Where(d => d.StatusId != 2 && d.StatusId != 5).Where(d => d.DonorId == k.Id).Select(d => new DonorMojeAktivneDonacijeVM.Row
                {
                    DonacijaId = d.DonacijaId,
                    StatusOpis = d.Status.Opis,
                    TipDonacije = d.TipDonacije.Tip,
                    StatusId = d.StatusId,
                    PrimalacId = (int)d.PrimalacId
                }).ToList()
            };

            for (int i = 0; i < model.rows.Count; i++)
            {
                var primalacKorisnik = db.Primalac.Where(p => p.KorisnikId == model.rows[i].PrimalacId).SingleOrDefault();

                if (primalacKorisnik != null)
                {
                    string licniNaziv = db.Korisnik.Where(a => a.Id == primalacKorisnik.KorisnikId).Include(a => a.LicniPodaci).SingleOrDefault().LicniPodaci.Naziv;
                    model.rows[i].LicniPodaciNaziv = licniNaziv;
                }
                else
                {
                    model.rows[i].LicniPodaciNaziv = "?";
                }
            }

            PostaviViewBag(k.Id, "MojeAktivneDonacije");
            return View(model);
        }

        public ActionResult ObezbjediTransport(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);

            d.TransportId = k.Id;
            d.StatusId = 4;

            Obavijest o = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 2,
                TipObavijestiId = 6,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.PrimalacId
            };

            db.Obavijest.Add(o);
            db.SaveChanges();

            _hubContext.Clients.All.SendAsync("ReceiveNotification", o.ZaKorisnikId);

            return RedirectToAction("MojeAktivneDonacije");
        }

        public ActionResult IzbrisiObavijest(int obavijestId)
        {
            Obavijest o = db.Obavijest.Find(obavijestId);

            if (o != null)
            {
                db.Obavijest.Remove(o);
                db.SaveChanges();
            }

            return RedirectToAction("Obavijesti");
        }

        public ActionResult PrihvatiZahtjev(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);
            d.StatusId = 3;

            Obavijest o = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 2,
                TipObavijestiId = 3,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.PrimalacId
            };
            db.Obavijest.Add(o);
            db.SaveChanges();

            _hubContext.Clients.All.SendAsync("ReceiveNotification", o.ZaKorisnikId);

            PostaviViewBag(k.Id, "MojeAktivneDonacije");
            ViewBag.donacijaId = donacijaId;
            return View();
        }

        public ActionResult Doniraj(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 1)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);
            d.StatusId = 3;
            d.DonorId = k.Id;

            Obavijest o = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 2,
                TipObavijestiId = 8,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.PrimalacId
            };
            db.Obavijest.Add(o);
            db.SaveChanges();

            _hubContext.Clients.All.SendAsync("ReceiveNotification", o.ZaKorisnikId);

            PostaviViewBag(k.Id, "PregledPotreba");
            ViewBag.donacijaId = donacijaId;
            return View("PrihvatiZahtjev");
        }
        public void PostaviViewBag(int KorisnikId, string active)
        {
            ViewBag.brojObavijesti = db.Obavijest.Where(o => o.ZaKorisnikId == KorisnikId).Count();
            ViewBag.Active = active;
        }
    }
}