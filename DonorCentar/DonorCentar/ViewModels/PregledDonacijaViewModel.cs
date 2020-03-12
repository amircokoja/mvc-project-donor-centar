using DonorCentar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc;


namespace DonorCentar.ViewModels
{
    public class PregledDonacijaViewModel
    {
        public Donacija Donacija { get; set; }
        public int ObavijestiId { get; set; }
    }
}
