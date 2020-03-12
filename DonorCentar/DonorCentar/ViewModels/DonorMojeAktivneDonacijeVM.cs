using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class DonorMojeAktivneDonacijeVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int DonacijaId { get; set; }
            public string LicniPodaciNaziv { get; set; }
            public string TipDonacije { get; set; }
            public string StatusOpis { get; set; }
            public int StatusId { get; set; }
            public int PrimalacId { get; set; }
        }
    }
}
