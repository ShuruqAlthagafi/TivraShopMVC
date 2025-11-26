using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TivraShopMVC.Data;
using TivraShopMVC.Filters;
using TivraShopMVC.Interfaces;
using TivraShopMVC.Models;

namespace TivraShopMVC.Controllers
{
    [SessionAuthorize(AllowedRole = "Client")]

    public class ClientController : Controller
    {

        // private readonly ApplicationDbContext _context;

        private readonly IRepository<Client> _repositoryClint;
        public ClientController(IRepository<Client> repository)
        {
            _repositoryClint = repository;
        }
        //public ClientController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Index()
        {
            
            try {

                //IEnumerable<Client> clients = _context.Clients.ToList();
                IEnumerable<Client> clients = _repositoryClint.GetAll();
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

            //_context.Clients.Add(client);
            //_context.SaveChanges();
            _repositoryClint.Add(client);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(string Uid)
        {
           // var clients = _context.Clients.FirstOrDefault(e=>e.Uid == Uid);
            var clients = _repositoryClint.GetByUId(Uid);
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

               // var cli = _context.Clients.FirstOrDefault(e => e.Uid == Uid);
                var cli = _repositoryClint.GetByUId(Uid);
                if (cli != null)
                {

                   
                    clients.FullName = cli.FullName;
                    clients.Email = cli.Email;
                    //_context.Clients.Update(cli);
                    //_context.SaveChanges();
                    _repositoryClint.Update(clients);
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
            //var client = _context.Clients.Find(Id);
            var client = _repositoryClint.GetById(Id);
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Client client)
        {
            try
            {
                //_context.Clients.Remove(client);
                //_context.SaveChanges();
                _repositoryClint.Delete(client.Id);
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

           // var client = _context.Clients.FirstOrDefault(c => c.Email == email);
            var client = _repositoryClint.GetAll().FirstOrDefault(c => c.Email == email);
            return View(client);
        }
    }
}
