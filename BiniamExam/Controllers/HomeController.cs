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

        public static string adminEmail = "admin@email.com";
        public static string adminPassword = "admin";
        public static string customerEmail = "customer@email.com";
        public static string customerPassword = "customer";
        public static IList<Customer> customers = new List<Customer> { };

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

        public IActionResult Validate(Login values) {
            if(values.email == adminEmail && values.password == adminPassword) { return RedirectToAction("Index", "Admin"); }
            if (values.email == customerEmail && values.password == customerPassword) { return RedirectToAction("Index", "Customer");}

            foreach (var eachUser in customers)
            {
                if (eachUser.email == values.email && eachUser.password == values.password)
                {
                    string name = eachUser.name;
                    return RedirectToAction("Index", "Customer", name);
                }
            }
            return Content("Account not found");
        }

        public IActionResult NewUser(Customer details)
        {
            customers.Add(details);
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}