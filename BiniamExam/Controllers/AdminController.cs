using BiniamExam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiniamExam.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

  

        //GET
        public IActionResult AddUser()
        {
            
            return View();
        }

        public IActionResult ViewList()
        { 
            return View();
        }
    }    
}
