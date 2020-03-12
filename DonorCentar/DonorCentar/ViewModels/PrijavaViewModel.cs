namespace DonorCentar.ViewModels
{
    public class PrijavaViewModel
    {
        public string KorisnickoIme { get; set; }
        [PrijavaValidation]
        public string Sifra { get; set; }

    }
}
