using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Modeli;
using WebApplication1.ModulNarudzba.ViewModel;
using WebApplication1.ModulProizvod.ViewModel;

namespace WebApplication1.ModulProizvod
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProizvodKontroler:ControllerBase
    {
        private ApplicationDbContext _dbContext;

        private readonly ILogger _logger;

        public ProizvodKontroler(ApplicationDbContext dbContext, ILogger<ProizvodKontroler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public List<Proizvod>GetAll()
        {
            return _dbContext.Proizvod.ToList();
        }

        [HttpPost]
        public ActionResult DodajProizvod(ProizvodDodaj model)
        {
            var proizvod = new Proizvod();
            var existingProduct = _dbContext.Proizvod.Where(x => x.Naziv == model.Naziv).FirstOrDefault();

            if (existingProduct != null)
            {
                return BadRequest("Proizvod vec postoji!");
            }

            _logger.Log(LogLevel.Information, "Dodavanje proizvoda!");
            try
            {
                proizvod.Naziv = model.Naziv;
                proizvod.Opis = model.Opis;
                proizvod.Cijena = model.Cijena;

                _dbContext.Proizvod.Add(proizvod);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return Ok(proizvod);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Proizvod proizvod = _dbContext.Proizvod.Find(id);
            _dbContext.Proizvod.Remove(proizvod);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
