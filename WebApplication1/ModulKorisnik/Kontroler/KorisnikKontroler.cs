using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modeli;

namespace WebApplication1.ModulKorisnik.Kontroler
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikKontroler:ControllerBase
    {
        private ApplicationDbContext _dbContext;
        public KorisnikKontroler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public List<Korisnik>GetAll()
        {
            return _dbContext.Korisnik.ToList();
        }
    }
}
