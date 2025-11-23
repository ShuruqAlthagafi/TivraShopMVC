using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Models;


namespace TivraShopMVC.Controllers
{
    [SessionAuthorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _context.Orders.Include(c => c.Client).ToList();
            return View(orders);
        }
        private void createList()
        {
            IEnumerable<Client> clients = _context.Clients.ToList();
            SelectList selectListItems = new SelectList(clients, "Id", "FullName");
            ViewBag.clients = selectListItems;



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
        public IActionResult Create(Order orders)
        {
            _context.Orders.Add(orders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

            var orders = _context.Orders.Find(id);
            createList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult Edit(Order orders)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(orders);

                }
                _context.Orders.Update(orders);
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
            var order = _context.Orders.Find(Id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            try
            {
                _context.Orders.Remove(order);
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