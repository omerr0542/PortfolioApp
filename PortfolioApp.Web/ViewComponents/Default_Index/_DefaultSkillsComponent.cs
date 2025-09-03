using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultSkillsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var skills = context.Skills.OrderByDescending(s => s.Percentage).ToList();
            return View(skills);
        }
    }
}
