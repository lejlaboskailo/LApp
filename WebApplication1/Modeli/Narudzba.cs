using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Modeli;

namespace WebApplication1
{
    public class Narudzba
    {
        public int NarudzbaId { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        [ForeignKey("Proizvod")]
        public int? ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
        public DateTime Datum { get; set; }
        public float Ukupno { get; set; }

    }
}
