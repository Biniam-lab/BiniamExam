using BiniamExam.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Diagnostics;
using System.Linq;

namespace BiniamExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NoAccount()
        {
            return View();
        }

        public IActionResult Validate(Login values) {
            if(values.email == UserData.adminEmail && values.password == UserData.adminPassword) { return RedirectToAction("Index", "Admin"); }
            if (values.email == UserData.customerEmail && values.password == UserData.customerPassword) { return RedirectToAction("Index", "Customer");}

            foreach (var eachUser in UserData.customers)
            {
                if (eachUser.email == values.email && eachUser.password == values.password)
                {
                    TempData["name"] = eachUser.name;
                    return RedirectToAction("Index", "Customer");
                }
            }
            return RedirectToAction("NoAccount", "Home");
        }

        public IActionResult NewUser(Customer details)
        {
            UserData.customers.Add(details);
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}