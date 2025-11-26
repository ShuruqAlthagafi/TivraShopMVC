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
            
            try {

                IEnumerable<Client> clients = _context.Clients.ToList();
                //foreach (var item in clients)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    _context.Clients.Update(item);
                //    _context.SaveChanges();
                //}
                return View(clients);
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
        public IActionResult Edit(string Uid)
        {
            var clients = _context.Clients.FirstOrDefault(e=>e.Uid == Uid);
            return View(clients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client clients, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(clients);

                }

                var cli = _context.Clients.FirstOrDefault(e => e.Uid == Uid);
                if (cli != null)
                {

                   
                    clients.FullName = cli.FullName;
                    clients.Email = cli.Email;
                    _context.Clients.Update(cli);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(clients);


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
        [ValidateAntiForgeryToken]
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
