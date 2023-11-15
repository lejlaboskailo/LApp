using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Modeli;
using WebApplication1.ModulNarudzba.ViewModel;

namespace WebApplication1.ModulNarudzba
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NarudzbaKontroler:ControllerBase
    {
        private ApplicationDbContext _dbContext;
        public NarudzbaKontroler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Narudzba>GetAll()
        {
            return _dbContext.Narudzba.ToList();
        }

        [HttpPost]
        public ActionResult DodajNarudzbu(NarudzbaDodaj model)
        {
            var narudzba = new Narudzba()
            {
                KorisnikId = model.KorisnikId,
                ProizvodId = model.ProizvodId,
                Datum = model.Datum,
                Kolicina = model.Kolicina,
                Ukupno = model.Ukupno
            };
            _dbContext.Narudzba.Add(narudzba);
            _dbContext.SaveChanges();

            return Ok(narudzba);

        }
        [HttpGet("{id}")]
        public ActionResult Delete(int id)
        {
            Narudzba narudzba = _dbContext.Narudzba.Find(id);
            _dbContext.Narudzba.Remove(narudzba);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
