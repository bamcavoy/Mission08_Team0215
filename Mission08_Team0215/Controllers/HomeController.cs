using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.UserTask = _repo.UserTask.ToList();

            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task(Task t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddUserTask(t);
                return RedirectToAction("Quadrant");
            }
            return View(t);
        }
    }
}
