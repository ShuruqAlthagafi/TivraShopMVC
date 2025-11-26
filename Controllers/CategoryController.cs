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
            try {
                IEnumerable<Category> categories = _context.Categories.ToList();
                //foreach (var item in categories)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Categories.Update(item);
                //    _context.SaveChanges();
                //}
                return View(categories);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
           

        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            var category = _context.Categories.FirstOrDefault(e=>e.Uid == Uid);
            return View(category);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(category);

                }

                var cat = _context.Categories.FirstOrDefault(e => e.Uid == Uid);
                if (cat != null)
                {

                    //category.Id = cat.Id;
                    category.Name = cat.Name;
                    category.Description = cat.Description;
                    _context.Categories.Update(cat);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(category);

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
        [ValidateAntiForgeryToken]
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
