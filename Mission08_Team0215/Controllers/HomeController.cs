using Microsoft.AspNetCore.Mvc;
//using Mission08_Team0215.Models;
using System.Diagnostics;

namespace Mission08_Team0215.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
