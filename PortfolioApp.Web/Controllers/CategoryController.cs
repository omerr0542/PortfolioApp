using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Web.Context;
using PortfolioApp.Web.Entities;

namespace PortfolioApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category c)
        {
            if (c == null)
                return null;

            _context.Categories.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var c = _context.Categories.Find(id);
            _context.Categories.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var c = _context.Categories.Find(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category c)
        {
            if (c == null)
                return null;
            var category = _context.Categories.Find(c.CategoryId);
            if (category != null)
            {
                category.CategoryName = c.CategoryName;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
