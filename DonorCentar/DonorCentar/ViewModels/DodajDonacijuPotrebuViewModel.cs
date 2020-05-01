using DonorCentar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class DodajDonacijuPotrebuViewModel
    {
        public List<SelectListItem> TipDonacije { get; set; }
        [Required(ErrorMessage = "Izaberite tip donacije")]
        public int? TipDonacijeId { get; set; }
        [Required(ErrorMessage = "Unesite opis donacije")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Unesite kolicinu")]
        [Range(0,9999999, ErrorMessage = "Unesite broj")]
        public int? Kolicina { get; set; }
        [Required(ErrorMessage = "Izaberite jedinicu mjere")]
        public JedinicaMjere? JedinicaMjere { get; set; }
        public int DonacijaId { get; set; }
    }
}
