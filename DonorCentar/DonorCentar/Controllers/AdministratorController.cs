using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Helper;
using DonorCentar.Models;
using DonorCentar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using X.PagedList;
using X.PagedList.Mvc.Core;


namespace DonorCentar.Controllers
{
    public class AdministratorController : Controller
    {
        private BazaPodataka db = new BazaPodataka();

        public IActionResult Index()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            AdminViewModel viewModel = new AdminViewModel
            {
                KorisnickoIme = k.LoginPodaci.KorisnickoIme,
                tipKorisnika = "Administrator"
            };

            ViewBag.Active = "Index";
            return View(viewModel);
        }


        /*Zavrseno*/
        public ActionResult Obavijesti()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ObavijestiVM model = new ObavijestiVM
            {
                rows = db.Obavijest.Where(d => d.TipKorisnikaId == 4).Select(o => new ObavijestiVM.Row
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
            model.rows = model.rows.OrderByDescending(m => m.ObavijestId).ToList();

            ViewBag.Active = "Obavijesti";
            return View(model);
        }

        /*Zavrseno*/
        public ActionResult NeverifikovaniPrimaoci()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            //List<int> korisnikId = db.Primalac.Where(p => p.Verifikovan == false).Select(p => p.KorisnikId).ToList();
            //List<Korisnik> korisnici = new List<Korisnik>();
            //foreach (var x in korisnikId)
            //{
            //    korisnici.Add(db.Korisnik
            //        .Include(k => k.LicniPodaci)
            //        .Include(k => k.Grad)
            //        .Where(k => k.Id == x).FirstOrDefault());
            //}
            //korisnici = korisnici.OrderByDescending(t => t.Id).ToList();

            //return View(korisnici.ToPagedList(page ?? 1,5));

            ViewBag.Active = "NeverifikovaniPrimaoci";
            return View();
        }

        /*Zavrseno*/
        public ActionResult Verifikuj(int korisnikId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            db.Primalac.Where(d => d.KorisnikId == korisnikId).FirstOrDefault().Verifikovan = true;
            db.SaveChanges();

            return RedirectToAction("NeverifikovaniPrimaoci");
        }
        public ActionResult DodajAdmina()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "DodajAdmina";
            return View();
        }
        public ActionResult OstaliKorisnici()
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }

            ViewBag.Active = "OstaliKorisnici";
            return View();
        }

        /*Zavrseno*/
        public ActionResult IzbrisiObavijest(int obavijestId)
        {
            Korisnik k = HttpContext.GetLogiraniKorisnik();
            if (k == null || k.TipKorisnikaId != 4)
            {
                ViewData["error_poruka"] = "Nemate pravo pristupa.";
                return View("../Home/Index");
            }
            Obavijest o = db.Obavijest.Find(obavijestId);

            db.Obavijest.Remove(o);
            db.SaveChanges();

            return RedirectToAction("Obavijesti");
        }
    }

}