using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultSendMessageComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
