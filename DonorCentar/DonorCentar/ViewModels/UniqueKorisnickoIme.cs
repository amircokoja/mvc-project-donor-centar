using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DonorCentar.Models;


namespace DonorCentar.ViewModels
{
    public class UniqueKorisnickoIme : ValidationAttribute
    {
//        private BazaPodataka db = new BazaPodataka();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var db = (BazaPodataka)validationContext.GetService(typeof(BazaPodataka));

            var korisnik = (HomeRegistracijaVM)validationContext.ObjectInstance;

            var loginP = db.LoginPodaci.ToList();

            foreach (var lp in loginP)
            {
                if(korisnik.KorisnickoIme == lp.KorisnickoIme)
                {
                    return new ValidationResult("Korisničko ime već postoji");
                }
            }
            return ValidationResult.Success;
        }
    }
}
