using BiniamExam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiniamExam.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.name = name;
            return View();
        }

        

    }
}
