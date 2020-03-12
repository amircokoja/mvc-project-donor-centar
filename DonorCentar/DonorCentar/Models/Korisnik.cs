using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DonorCentar.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public LoginPodaci LoginPodaci { get; set; }
        public int LoginPodaciId { get; set; }
        public LicniPodaci LicniPodaci { get; set; }
        public int LicniPodaciId { get; set; }
        public Grad Grad { get; set; }
        public int GradId { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public int TipKorisnikaId { get; set; }
    }
}
