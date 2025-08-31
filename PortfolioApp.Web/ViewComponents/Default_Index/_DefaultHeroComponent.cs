using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultHeroComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var banner = context.Banners.Any() ? context.Banners.FirstOrDefault() : null;
            return View(banner);
        }
    }
}
