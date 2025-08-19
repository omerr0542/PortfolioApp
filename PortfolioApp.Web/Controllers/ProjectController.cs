using AspNetCoreGeneratedDocument;
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


        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var project = context.Projects.Find(id);
            CategoryDropdownList();
            return View(project);

        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                CategoryDropdownList();
                return View(project);
            }

            context.Projects.Update(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
