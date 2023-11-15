using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Autentifikacija_Autorizacija
{
    public class Autorizacija : TypeFilterAttribute
    {
        public Autorizacija(bool korisnik)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { };
        }
    }


    public class MyAuthorizeImpl : IActionFilter
    {
        private readonly bool _admin;
        private readonly bool _uposlenik;
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.GetLoginInfo().isLogiran)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            filterContext.Result = new UnauthorizedResult();
        }
    }
}
