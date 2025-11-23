using Microsoft.AspNetCore.Mvc;
using TivraShopMVC.Filters;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize]
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
