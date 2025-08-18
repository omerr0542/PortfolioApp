using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Entities;

namespace PortfolioApp.Web.Controllers
{
    // Bu şekilde context'i controller'a enjekte ederek kullanabiliriz. Primary Constructor injection ile.
    public class ProjectController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var projects = context.Projects.Include(x => x.Category).ToList();
            return View(projects);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            CategoryDropdownList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if(!ModelState.IsValid)
            {
                CategoryDropdownList();
                return View(project);
            }

            context.Projects.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CategoryDropdownList()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();
        }
    }
}
