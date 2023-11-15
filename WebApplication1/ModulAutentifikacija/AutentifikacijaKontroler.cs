using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Autentifikacija_Autorizacija;
using WebApplication1.Data;
using WebApplication1.Modeli;
using WebApplication1.ModulAutentifikacija.ViewModel;
using static WebApplication1.Autentifikacija_Autorizacija.MyAuthTokenExtension;

namespace WebApplication1.ModulAutentifikacija
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaKontroler:ControllerBase
    {
        private ApplicationDbContext _dbContext;
        
        public AutentifikacijaKontroler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] Login loginVM)
        {
            KorisnickiNalog logiraniKorisnik = _dbContext.KorisnickiNalog
                .FirstOrDefault(k => k.KorisnickoIme != null && k.KorisnickoIme == loginVM.KorisnickoIme && k.Lozinka == loginVM.Lozinka);

            if (logiraniKorisnik == null)
            {
                return new LoginInformacije(null);
            }

            string randomString = TokenGenerator.Generate(10);


            var noviToken = new AutentifikacijaToken()
            {
                IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();
            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();
            return autentifikacijaToken;
        }

        [HttpGet("{id}")]
        public KorisnickiNalog GetUser(int id)
        {
            return _dbContext.KorisnickiNalog.Find(id);
        }
    }
}
