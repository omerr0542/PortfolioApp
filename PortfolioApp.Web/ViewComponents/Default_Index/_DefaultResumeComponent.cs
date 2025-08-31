using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Models;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultResumeComponent (PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new ResumeViewModel
            {
                Experiences = context.Experiences.OrderByDescending(exp => exp.ExperienceId).ToList(),
                Educations = context.Educations.OrderByDescending(edu => edu.EndYear).ToList()
            };
            return View(model);
        }
    }
}
