using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultAboutComponent (PortfolioContext context): ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var about = context.Abouts.FirstOrDefault();
            return View(about);
        }
    }
}
