using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DonorCentar.ViewModels;

namespace DonorCentar.Models
{
    public class LicniPodaci
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; } 
    }
}
