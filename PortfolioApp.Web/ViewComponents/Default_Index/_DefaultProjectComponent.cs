using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultProjectComponent (PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categoriesWithProjects = context.Categories.Include(c => c.Projects).ToList();
            return View(categoriesWithProjects);
        }
    }
}
