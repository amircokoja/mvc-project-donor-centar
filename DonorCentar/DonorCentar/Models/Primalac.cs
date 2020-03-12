using System;
using System.Collections.Generic;
using System.Text;


namespace DonorCentar.Models
{
    public class Primalac
    {
        public int Id { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool Verifikovan { get; set; }
    }
}
