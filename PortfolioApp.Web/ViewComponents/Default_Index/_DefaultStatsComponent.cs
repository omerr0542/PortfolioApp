using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Models;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent(PortfolioContext context) : ViewComponent
    {
        StatsModel model = new()
        {
            SkillsCount = context.Skills.Count(),
            ProjectsCount = context.Projects.Count(),
            MessagesCount = context.UserMessages.Count(),
            TestimonialsCount = context.Testimonials.Count()
        };

        public IViewComponentResult Invoke()
        {
            return View(model);
        }
    }
}
