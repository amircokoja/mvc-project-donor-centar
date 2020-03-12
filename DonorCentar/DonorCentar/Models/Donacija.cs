using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DonorCentar.Models
{
    public enum JedinicaMjere
    {
        kom, g, kg, l, KM
    }

    public class Donacija
    {
        public int DonacijaId { get; set; }
        public TipDonacije TipDonacije { get; set; }
        [Required(ErrorMessage = "Izaberite tip donacije")]
        public int? TipDonacijeId { get; set; }
        [Required(ErrorMessage = "Unesite opis")]
        public string Opis { get; set; }
        
        [Required(ErrorMessage = "Unesite kolicinu")]
        [Range(1, 9999999999999999.99, ErrorMessage = "Unesite veći od jedan")]
        public decimal Kolicina { get; set; }

        [Required(ErrorMessage = "Izaberite jedinicu mjere")]
        public JedinicaMjere? JedinicaMjere { get; set; }

        public Korisnik Primalac { get; set; }
        public int? PrimalacId { get; set; }

        public Korisnik Donor { get; set; }
        public int? DonorId { get; set; }
        public Korisnik Transport { get; set; }
        public int? TransportId { get; set; }

        public VrstaDonacije VrstaDonacije { get; set; }
        public int VrstaDonacijeId { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }

        public InformacijeTransporta Informacije { get; set; }
        public int? InformacijeId { get; set; }
    }
}
