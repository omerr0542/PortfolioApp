using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Context;

namespace PortfolioApp.Web.Controllers
{
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ProjectCount = context.Projects.Count();
            ViewBag.SkillAverage = context.Skills.Any() ? context.Skills.Average(s => s.Percentage).ToString("F2") : "0.0";
            ViewBag.UnreadMessageCount = context.UserMessages.Count(s => s.IsRead == false);
            ViewBag.LastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId)
                                                            .Select(x => x.Name)
                                                            .FirstOrDefault();

            int totalExperience = 0;
            foreach (var exp in context.Experiences)
            {
                totalExperience += (String.IsNullOrEmpty(exp.EndYear) ? DateTime.Now.Year : Convert.ToInt32(exp.EndYear)) - exp.StartYear;
            }
            ViewBag.ExperienceYear = totalExperience;

            ViewBag.CompanyCount = context.Experiences.ToList().DistinctBy(e => e.CompanyName).Count(); // veya context.Experiences.GroupBy(e => e.CompanyName).Count();
            ViewBag.ReviewAverage = context.Testimonials.Any() ? context.Testimonials.Average(t => t.Review).ToString("F2") + " /5" : "Henüz Bir Değerlendirme Yapılmadı";
            ViewBag.MaxReviewOwner = context.Testimonials.Any() ? context.Testimonials.ToList().OrderByDescending(t => t.Review).ToList().First().Name : "Henüz Bir Değerlendirme Yapılmadı";

            return View();
        }
    }
}
