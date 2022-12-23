using BiniamExam.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

       public IActionResult Delete()
        {
            return View();
        }

        public IActionResult NoAccount()
        {
            return View();
        }
      
        public IActionResult DeleteUser(Customer data)
        {
            
            foreach (var eachUser in UserData.customers)
            {
                if (eachUser.email == data.email)
                {
                    UserData.customers.Remove(eachUser);
                    
                    return RedirectToAction("ViewList", "Admin");
                }
            }
            return RedirectToAction("NoAccount", "Admin");
            
        }

       
    }    
}
