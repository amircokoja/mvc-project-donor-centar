using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DonorCentar.ViewModels
{
    public class HomeRegistracijaVM
    {
        [Required(ErrorMessage = "Izaberite tip korisnika")]
        public int? TipKorisnikaId { get; set; }
        [Required(ErrorMessage = "Unesite naziv")]
        [UniqueNaziv]
        [StringLength(100, ErrorMessage = "Naziv mora sadržavati minimalno 4 karaktera", MinimumLength = 4)]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Unesite email")]
        [StringLength(40)]
        [EmailAddress(ErrorMessage = "Unesite ispravnu email adresu (npr. donor@centar.ba")]
        [UniqueEmail]
        public string Email { get; set; }
        [Required(ErrorMessage = "Izaberite grad")]
        public int? GradId { get; set; }
        [Required(ErrorMessage = "Unesite adresu")]
        [StringLength(40)]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Unesite broj telefona")]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }
        [Required(ErrorMessage = "Unesite korisničko ime")]
        [StringLength(100, ErrorMessage = "Korisničko ime mora sadržavati minimalno 4 karaktera", MinimumLength = 4)]
        [UniqueKorisnickoIme]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Unesite šifru")]
        [StringLength(100, ErrorMessage = "Šifra mora sadržavati minimalno 4 karaktera", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Sifra { get; set; }
        [DataType(DataType.Password)]
        [Compare("Sifra", ErrorMessage = "Šifre se ne poklapaju")]
        public string PonoviSifru { get; set; }
        public List<SelectListItem> TipKorisnika { get; set; }
        public List<SelectListItem> Grad { get; set; }
    }
}
