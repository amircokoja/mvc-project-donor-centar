using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using DonorCentar.Models;

namespace DonorCentar.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik, bool snimiUCookie = false)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);

        }
        public static Korisnik GetLogiraniKorisnik(this HttpContext context)
        {
            Korisnik korisnik = context.Session.Get<Korisnik>(LogiraniKorisnik);

            return korisnik;
        }
    }
}