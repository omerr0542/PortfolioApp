using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.ViewComponents.Default_Index
{
    public class _DefaultTestimonialsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var testimonials = context.Testimonials.ToList(); 
            return View(testimonials);
        }
    }
}
