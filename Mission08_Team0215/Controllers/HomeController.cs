using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0215.Models;
using System.Diagnostics;

namespace Mission08_Team0215.Controllers
{
    public class HomeController : Controller
    {
        private IUserTaskRepository _repo;
        public HomeController(IUserTaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Quadrant()
        {
            ViewBag.Task = _repo.UserTask.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {
            return View(new Task());
        }

        [HttpPost]
        public IActionResult Task(Task t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddUserTask(t);
                return View(Quadrant);
            }


        }
    }
}
