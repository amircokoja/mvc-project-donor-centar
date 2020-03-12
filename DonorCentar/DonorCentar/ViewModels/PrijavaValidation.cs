using DonorCentar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class PrijavaValidation : ValidationAttribute
    {
        private BazaPodataka db;
        public PrijavaValidation()
        {
            db = new BazaPodataka();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var prijava = (PrijavaViewModel)validationContext.ObjectInstance;

            var loginP = db.LoginPodaci.ToList();

            foreach (var lp in loginP)
            {
                if (lp.KorisnickoIme == prijava.KorisnickoIme && lp.Sifra == prijava.Sifra)
                {
                    return ValidationResult.Success;

                }
            }
            return new ValidationResult("Korisničko ime ili šifra nisu ispravni.");
        }
    }
}
