using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
