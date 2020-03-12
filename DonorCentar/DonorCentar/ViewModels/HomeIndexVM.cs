using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class HomeIndexVM
    {
        [Required(ErrorMessage = "Unesite korisničko ime")]
        [StringLength(100, ErrorMessage = "Korisničko ime mora sadržavati minimalno 4 karaktera", MinimumLength = 4)]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Unesite šifru")]
        [StringLength(100, ErrorMessage = "Šifra mora sadržavati minimalno 4 karaktera", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
        public bool ZapamtiSifru { get; set; }
    }
}
