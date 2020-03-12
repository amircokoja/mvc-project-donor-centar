using DonorCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class PrimalacDetaljiDonacijeVM
    {
        public int DonacijaId { get; set; }
        public string DonorNaziv { get; set; }
        public string DonorAdresa { get; set; }
        public string DonorGrad { get; set; }
        public string TipDonacije { get; set; }
        public string Opis { get; set; }
        public decimal Kolicina { get; set; }
        public JedinicaMjere JedinicaMjere { get; set; }
        public int TransportId { get; set; }
        public int InformacijeId { get; set; }
    }
}
