using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Models;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            try
            {
                IEnumerable<Product> Products = _context.Products.Include(c => c.Category).ToList();
                //foreach ( var item in Products)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Products.Update(item);
                //    _context.SaveChanges();
                //}
                return View(Products);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }
        private void createList()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            SelectList selectListItems = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = selectListItems;



            //IEnumerable<Category> categories = _context.Categories.ToList();
            //ViewBag.Categories = categories;
        }


        [HttpGet]
        public IActionResult Create()
        {
            createList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(string Uid)
        {

            var product = _context.Products.FirstOrDefault(e=>e.Uid == Uid);
            createList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product , string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(product);

                }
                var pro = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == Uid);

                if (pro != null)
                {
                    product.Name = pro.Name;
                    product.Description = pro.Description;
                    _context.Products.Update(pro);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }







        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
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
