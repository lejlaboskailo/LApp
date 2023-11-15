using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Data;
using WebApplication1.Modeli;

namespace WebApplication1.Autentifikacija_Autorizacija
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }
            [JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }
            public bool isLogiran => korisnickiNalog != null;
            public bool isPermsijaKorisnik => isLogiran && (korisnickiNalog.isKorisnik);

        }
        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            AutentifikacijaToken token = httpContext.GetAuthToken();
            return new LoginInformacije(token);
        }
        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.KorisnickiNalog)
                .SingleOrDefault(x => token != null && x.Vrijednost == token);

            return korisnickiNalog;
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    }
}
