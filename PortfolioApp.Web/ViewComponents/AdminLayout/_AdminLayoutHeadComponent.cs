using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
