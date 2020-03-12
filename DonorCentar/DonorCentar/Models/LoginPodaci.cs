using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DonorCentar.ViewModels;

namespace DonorCentar.Models
{
    public class LoginPodaci
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
    }
}
