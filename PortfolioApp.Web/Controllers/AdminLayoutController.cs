using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
