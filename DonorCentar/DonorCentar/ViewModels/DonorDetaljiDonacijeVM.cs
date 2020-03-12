using DonorCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class DonorDetaljiDonacijeVM
    {
        public int DonacijaId { get; set; }
        public string PrimalacLicniPodaciNaziv { get; set; }
        public string PrimalacAdresa { get; set; }
        public string PrimalacGrad { get; set; }
        public string TipDonacije { get; set; }
        public string Opis { get; set; }
        public decimal Kolicina { get; set; }
        public JedinicaMjere JedinicaMjere { get; set; }
        public string StatusOpis { get; set; }
    }
}
