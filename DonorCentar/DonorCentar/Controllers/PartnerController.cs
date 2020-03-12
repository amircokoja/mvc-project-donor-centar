using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Helper;
using DonorCentar.Models;
using DonorCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DonorCentar.Controllers
{
    public class PartnerController : Controller
    {
        private BazaPodataka db = new BazaPodataka();

        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 3)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            int partnerId = db.Partner.Where(d => d.KorisnikId == k.Id).FirstOrDefault().Id;

            var korisnikViewModel = new KorisnikVM
            {
                Id = partnerId,
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
            ViewBag.Active = "Index";
            return View(korisnikViewModel);
        }
        public ActionResult Obavijesti()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 3)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "Obavijesti";
            return View();
        }
        public ActionResult DonacijeBezTransporta()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 3)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "DonacijeBezTransporta";
            return View();
        }
        public ActionResult HistorijaDonacija()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 3)
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
            if (k == null || k.TipKorisnikaId != 3)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "OstaliKorisnici";
            return View();
        }
    }
}