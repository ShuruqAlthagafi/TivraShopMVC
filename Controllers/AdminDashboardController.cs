using Microsoft.AspNetCore.Mvc;
using TivraShopMVC.Filters;

namespace TivraShopMVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        [SessionAuthorize(AllowedRole = "Admin")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
