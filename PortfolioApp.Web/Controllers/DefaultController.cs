using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Entities;

namespace PortfolioApp.Web.Controllers
{
    public class DefaultController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(UserMessage message)
        {
            context.UserMessages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
