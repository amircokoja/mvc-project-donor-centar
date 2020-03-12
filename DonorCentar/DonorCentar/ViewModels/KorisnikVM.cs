using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class KorisnikVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string TipKorisnika { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Grad { get; set; }
        public bool Verifikovan { get; set; }
        public int PozitivniDojmovi { get; set; }
        public int NeutralniDojmovi { get; set; }
        public int NegativniDojmovi { get; set; }
    }
}
