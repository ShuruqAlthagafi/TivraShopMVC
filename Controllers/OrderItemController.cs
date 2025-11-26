using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Models;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize]
    public class OrderItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders1 = _context.OrderItems
     .Include(o => o.Order)
     .ThenInclude(o => o.Client) 
     .Include(o => o.Product)
     .ToList();
            return View(orders1);
        }

        private void createList()
        {
            var orders = _context.Orders
                .Include(o => o.Client)
                .ToList();

            ViewBag.Orders = new SelectList(
                orders.Select(o => new {
                    o.Id,
                    Text = o.Client != null ? o.Client.FullName : $"Client #{o.ClientId}"
                }),
                "Id",
                "Text"
            );

            var products = _context.Products.ToList();
            ViewBag.Products = new SelectList(products, "Id", "Name");
        }

        [HttpGet]
        public IActionResult Create()
        {
            createList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderItem orders1)
        {
       
                _context.OrderItems.Add(orders1);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            var orders1 = _context.OrderItems.FirstOrDefault(e=>e.Uid == Uid);
            if (orders1 == null)
                return NotFound();

            createList();
            return View(orders1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderItem orders1 )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    createList();
                    return View(orders1);
                }

                var existingItem = _context.OrderItems.Find(id);
                if (existingItem == null)
                    return NotFound();

                existingItem.OrderId = orders1.OrderId;
                existingItem.ProductId = orders1.ProductId;
                existingItem.Quantity = orders1.Quantity;
                existingItem.UnitPrice = orders1.UnitPrice;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("حدث خطأ غير متوقع، يرجى مراجعة الدعم الفني: 0565455252545");
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var orderItems = _context.OrderItems.Find(Id);
            return View(orderItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(OrderItem orderItems)
        {
            try
            {
                _context.OrderItems.Remove(orderItems);
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