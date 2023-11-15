using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Modeli
{
    [Table("Korisnik")]
    public class Korisnik: KorisnickiNalog
    {
        public string Adresa { get; set; }
        public string BrTelefona { get; set; }

    }
}
