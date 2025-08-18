using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
