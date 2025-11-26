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
           
            try 
            {
                IEnumerable<Order> orders = _context.Orders.Include(c => c.Client).ToList();
                //foreach ( var item in orders)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Orders.Update(item);
                //    _context.SaveChanges();
                //}
                return View(orders);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order orders)
        {
            _context.Orders.Add(orders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(string Uid)
        {

            var orders = _context.Orders.FirstOrDefault(e=>e.Uid == Uid);
            createList();
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order orders , string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(orders);

                }
                var ord = _context.Orders.FirstOrDefault(e => e.Uid == Uid);

                if (ord != null)
                {
                    orders.OrderDate = ord.OrderDate;
                    orders.Client = ord.Client;
                    _context.Orders.Update(ord);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
               return View(orders);

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
        [ValidateAntiForgeryToken]
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