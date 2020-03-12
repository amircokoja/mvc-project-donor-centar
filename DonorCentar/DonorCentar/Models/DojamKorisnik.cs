using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.Models
{
    public class DojamKorisnik
    {
        public int Id { get; set; }
        public Dojam Dojam { get; set; }
        public int DojamId { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public DateTime Datum { get; set; }
        public Donacija Donacija { get; set; }
        public int DonacijaId { get; set; }
        public string Opis { get; set; }
    }
}
