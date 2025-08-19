using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
