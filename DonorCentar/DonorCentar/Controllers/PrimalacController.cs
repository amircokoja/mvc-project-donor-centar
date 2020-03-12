using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Helper;
using DonorCentar.Models;
using DonorCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Mvc.Core;


namespace DonorCentar.Controllers
{
    public class PrimalacController : Controller
    {
        private BazaPodataka db = new BazaPodataka();

        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            int primalacId = db.Primalac.Where(p => p.KorisnikId == k.Id).FirstOrDefault().Id;
            bool verifikovan = db.Primalac.Where(p => p.KorisnikId == k.Id).FirstOrDefault().Verifikovan;

            var korisnikViewModel = new KorisnikVM
            {
                Id = primalacId,
                Naziv = k.LicniPodaci.Naziv,
                TipKorisnika = k.TipKorisnika.Tip,
                Adresa = k.LicniPodaci.Adresa,
                BrojTelefona = k.LicniPodaci.BrojTelefona,
                Email = k.LicniPodaci.Email,
                Grad = k.Grad.Naziv,
                Verifikovan = verifikovan,
                PozitivniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 1),
                NeutralniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 2),
                NegativniDojmovi = db.DojamKorisnik.Where(d => d.KorisnikId == k.Id).Count(d => d.DojamId == 3)
            };

            ViewBag.Active = "Index";
            return View(korisnikViewModel);
        }
        public ActionResult Obavijesti()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
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

            ViewBag.Active = "Obavijesti";
            return View(model);
        }

        public ActionResult DodajPotrebu()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            var viewModel = new DodajDonacijuPotrebuViewModel
            {
                TipDonacije = db.TipDonacije.Select(t => new SelectListItem { Value = t.TipDonacijeId.ToString(), Text = t.Tip }).ToList(),
            };

            ViewBag.Active = "DodajPotrebu";
            return View(viewModel);
        }

        public ActionResult Uredi(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija donacija = db.Donacija.Find(donacijaId);

            DodajDonacijuPotrebuViewModel viewModel = new DodajDonacijuPotrebuViewModel
            {
                TipDonacije = db.TipDonacije.Select(t => new SelectListItem { Value = t.TipDonacijeId.ToString(), Text = t.Tip }).ToList(),
                DonacijaId = donacija.DonacijaId,
                JedinicaMjere = (JedinicaMjere)donacija.JedinicaMjere,
                Kolicina = (int)donacija.Kolicina,
                Opis = donacija.Opis,
                TipDonacijeId = donacija.TipDonacijeId
            };

            return View("DodajPotrebu", viewModel);
        }

        public ActionResult IzbrisiObavijest(int obavijestId)
        {
            Obavijest o = db.Obavijest.Find(obavijestId);
            db.Obavijest.Remove(o);
            db.SaveChanges();

            return RedirectToAction("Obavijesti");
        }

        public ActionResult IzbrisiPotrebu(int donacijaId, int? page2)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);
            db.Donacija.Remove(d);
            db.SaveChanges();

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.DonorId == null)
                .Where(s => s.PrimalacId == k.Id)
                .Where(s => s.VrstaDonacijeId == 2)
                .Include(s => s.Status)
                .Include(s => s.TipDonacije)
                .ToList();

            ViewBag.Prikazi = "prikazi";

            return View("MojePotrebe", donacija.ToPagedList(page2 ?? 1, 5));
        }


        public ActionResult SpasiPotrebu(DodajDonacijuPotrebuViewModel viewModel)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = new Donacija
            {
                JedinicaMjere = (JedinicaMjere)viewModel.JedinicaMjere,
                Kolicina = (int)viewModel.Kolicina,
                Opis = viewModel.Opis,
                PrimalacId = k.Id,
                StatusId = 2,
                TipDonacijeId = viewModel.TipDonacijeId,
                VrstaDonacijeId = 2
            };

            if (viewModel.DonacijaId == 0)
            {
                db.Donacija.Add(d);
            }
            else
            {
                var objectDb = db.Donacija.Find(viewModel.DonacijaId);
                objectDb.JedinicaMjere = (JedinicaMjere)viewModel.JedinicaMjere;
                objectDb.Kolicina = (int)viewModel.Kolicina;
                objectDb.Opis = viewModel.Opis;
                objectDb.TipDonacijeId = viewModel.TipDonacijeId;
            }

            db.SaveChanges();
            ViewBag.Prikazi = "prikazi";

            return RedirectToAction("MojePotrebe");
        }

        public ActionResult MojePotrebe(int? page)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.DonorId == null).Where(s => s.PrimalacId == k.Id).Where(s => s.VrstaDonacijeId == 2).Include(s => s.Status).Include(s => s.TipDonacije).ToList();

            ViewBag.Active = "MojePotrebe";
            return View(donacija.ToPagedList(page ?? 1, 5));
        }

        public ActionResult PregledDonacija(int? page)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.StatusId == 1)
                .Where(s => s.VrstaDonacijeId == 1).Include(s => s.Status).Include(s => s.TipDonacije).
                Include(s => s.Donor.LicniPodaci).ToList();

            ViewBag.Active = "PregledDonacija";
            return View(donacija.ToPagedList(page ?? 1, 4));
        }

        public ActionResult ZatrazeneDonacije(int? page)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.StatusId == 6 || s.StatusId == 4 || s.StatusId == 3)
            .Where(s => s.PrimalacId == k.Id)
            .Include(s => s.Status).Include(s => s.TipDonacije)
            .Include(s => s.Donor)
            .Include(s => s.Donor.LicniPodaci).ToList();

            ViewBag.Active = "ZatrazeneDonacije";
            return View(donacija.ToPagedList(page ?? 1, 5));
        }

        public ActionResult DetaljiDonacije(int donacijaId, int akcija)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            PrimalacDetaljiDonacijeVM model = db.Donacija.Where(d => d.DonacijaId == donacijaId)
                .Select(d => new PrimalacDetaljiDonacijeVM
            {
                DonacijaId = d.DonacijaId,
                DonorAdresa = d.Donor.LicniPodaci.Adresa,
                DonorGrad = d.Donor.Grad.Naziv,
                DonorNaziv = d.Donor.LicniPodaci.Naziv,
                JedinicaMjere = (JedinicaMjere)d.JedinicaMjere,
                Kolicina = d.Kolicina,
                Opis = d.Opis,
                TipDonacije = d.TipDonacije.Tip,
                TransportId = (int)d.TransportId,
                InformacijeId = (int)d.InformacijeId
            }).SingleOrDefault();

            ViewBag.akcija = akcija;
            ViewBag.Active = "ZatrazeneDonacije";
            return View(model);
        }

        public ActionResult ZatraziDonaciju(int donacijaId, int? page)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }
            
            db.Donacija.Find(donacijaId).StatusId = 6;
            db.Donacija.Find(donacijaId).PrimalacId = k.Id;
            db.SaveChanges();

            int donorId = (int)db.Donacija.Find(donacijaId).DonorId;

            Obavijest obavijest = new Obavijest
            {
                DonacijaId = donacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 1,
                TipObavijestiId = 2,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = donorId
            };

            db.Obavijest.Add(obavijest);
            db.SaveChanges();

            ViewBag.Prikazi = "Zatrazeno";

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.StatusId == 6 || s.StatusId == 4 || s.StatusId == 3)
            .Where(s => s.VrstaDonacijeId == 1).Include(s => s.Status).Include(s => s.TipDonacije)
            .Include(s => s.Donor.LicniPodaci).ToList();

            return View("PregledDonacija", donacija.ToPagedList(page ?? 1, 5));
        }

        public ActionResult HistorijaDonacija()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "HistorijaDonacija";
            return View();
        }

        public ActionResult OstaliKorisnici()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "OstaliKorisnici";
            return View();
        }

        public ActionResult PonistiZahtjev(int donacijaId, int? page)
        {
            Donacija d = db.Donacija.Find(donacijaId);

            d.StatusId = 1;
            d.PrimalacId = null;

            db.SaveChanges();

            IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.StatusId == 6 || s.StatusId == 4 || s.StatusId == 3)
            .Where(s => s.VrstaDonacijeId == 1).Include(s => s.Status).Include(s => s.TipDonacije)
            .Include(s => s.Donor.LicniPodaci).ToList();

            ViewBag.Prikazi = "Ponisteno";

            return View("ZatrazeneDonacije", donacija.ToPagedList(page ?? 1, 5));
        }

        public ActionResult ObezbjediTransport(int donacijaId, int? page)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
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
                TipKorisnikaId = 1,
                TipObavijestiId = 4,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = (int)d.DonorId
            };

            db.Obavijest.Add(o);
            db.SaveChanges();


        IEnumerable<Donacija> donacija = db.Donacija.Where(s => s.StatusId == 6 || s.StatusId == 4 || s.StatusId == 3)
                .Where(s => s.VrstaDonacijeId == 1).Include(s => s.Status).Include(s => s.TipDonacije)
                .Include(s => s.Donor.LicniPodaci).ToList();

            ViewBag.Prikazi = "Transport";

            return View("ZatrazeneDonacije", donacija.ToPagedList(page ?? 1, 5));
        }

        public ActionResult DonacijaJeStigla(int donacijaId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            Donacija d = db.Donacija.Find(donacijaId);
            d.StatusId = 5;
            db.SaveChanges();

            PrimalacDonacijaJeStiglaVM model = new PrimalacDonacijaJeStiglaVM
            {
                ListaDojmova = db.Dojam.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.VrstaDojma
                }).ToList(),
                DonacijaId = donacijaId,
                KorisnikId = (int)d.DonorId
            };

            return View(model);
        }

        public ActionResult DodajDojam(PrimalacDonacijaJeStiglaVM model)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 2)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }


            DojamKorisnik dk = new DojamKorisnik
            {
                Datum = DateTime.Now,
                DojamId = (int)model.DojamId,
                DonacijaId = model.DonacijaId,
                Opis = model.Opis,
                KorisnikId = model.KorisnikId
            };

            Obavijest o = new Obavijest
            {
                DonacijaId = model.DonacijaId,
                OdKorisnikId = k.Id,
                TipKorisnikaId = 1,
                TipObavijestiId = 5,
                Vrijeme = DateTime.Now,
                ZaKorisnikId = model.KorisnikId
            };

            db.DojamKorisnik.Add(dk);
            db.Obavijest.Add(o);

            db.SaveChanges();

            return RedirectToAction("HistorijaDonacija");
        }

    }
}