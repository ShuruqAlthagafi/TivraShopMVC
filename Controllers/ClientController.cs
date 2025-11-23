using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Models;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize(AllowedRole = "Client")]

    public class ClientController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Client> clients = _context.Clients.ToList();
            return View(clients);
        }



        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {

                return View(client);
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var clients = _context.Clients.Find(Id);
            return View(clients);
        }

        [HttpPost]
        public IActionResult Edit(Client clients)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(clients);

                }
                _context.Clients.Update(clients);
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
            var client = _context.Clients.Find(Id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            try
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }


        }

        [HttpGet]
        public IActionResult Shop()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
                return RedirectToAction("Login", "Account");

            var client = _context.Clients.FirstOrDefault(c => c.Email == email);
            return View(client);
        }
    }
}
