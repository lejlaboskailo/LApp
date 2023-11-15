using Microsoft.Identity.Client;

namespace WebApplication1.Modeli
{
    public class KorisnickiNalog
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public Korisnik Korisnik => this as Korisnik;
        public bool isKorisnik { get; set; }

    }
}
