using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultContactComponent (PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contact = context.ContactInfos.ToList().Where(x => x.IsActive).ToList();
            return View(contact);
        }
    }
}
