using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class PrimalacDonacijaJeStiglaVM
    {
        public List<SelectListItem> ListaDojmova { get; set; }
        [Required(ErrorMessage = "Izaberite dojam")]
        public int? DojamId { get; set; }
        public string Opis { get; set; }
        public int DonacijaId { get; set; }
        public int KorisnikId { get; set; }
    }
}
