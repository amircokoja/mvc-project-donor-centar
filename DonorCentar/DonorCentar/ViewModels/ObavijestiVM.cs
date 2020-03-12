using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class ObavijestiVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int ZaKorisnikId { get; set; }
            public int OdKorisnikId { get; set; }
            public int ObavijestId { get; set; }
            public string Obavijest { get; set; }
            public string Naziv { get; set; }
            public DateTime Vrijeme { get; set; }
            public int TipKorisnikaId { get; set; }
            public int TipObavijestiId { get; set; }
        }
    }
}
