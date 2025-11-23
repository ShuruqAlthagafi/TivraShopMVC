using Microsoft.AspNetCore.Mvc;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Models;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize]
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(category);

                }
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Categories.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }
    }
}
