using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TivraShopMVC.Data;

namespace TivraShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{

        //    return View();
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("UserEmail");
            HttpContext.Session.Clear();
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var client = _context.Clients.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (client != null)
            {
                HttpContext.Session.SetString("UserEmail", client.Email);
                HttpContext.Session.SetString("UserRole", client.Role);

             
                if (client.Role == "Admin")
                    return RedirectToAction("Index", "AdminDashboard");
                else if (client.Role == "Client")
                    return RedirectToAction("Shop", "Client");

             
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }




    }
}
