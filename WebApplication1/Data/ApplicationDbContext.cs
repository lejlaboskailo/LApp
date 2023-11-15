using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Modeli;

namespace WebApplication1.Data
{

    public class ApplicationDbContext:DbContext
    {
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
