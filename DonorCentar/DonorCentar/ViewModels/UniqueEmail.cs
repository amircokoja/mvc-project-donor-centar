using DonorCentar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.ViewModels
{
    public class UniqueEmail : ValidationAttribute
    {
        private BazaPodataka db;
        public UniqueEmail()
        {
            db = new BazaPodataka();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var korisnik = (HomeRegistracijaVM)validationContext.ObjectInstance;

            var licniP = db.LicniPodaci.ToList();

            foreach (var lp in licniP)
            {
                if (korisnik.Email == lp.Email)
                {
                    return new ValidationResult("Email već postoji");
                }
            }
            return ValidationResult.Success;
        }
    }
}
