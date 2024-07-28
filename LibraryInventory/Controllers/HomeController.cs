using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Controllers
{
    public class HomeController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }       
    }
}