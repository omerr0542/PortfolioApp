using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
