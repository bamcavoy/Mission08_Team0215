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

            ViewBag.Category = _repo.Category.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult UserTaskForm()
        {
            ViewBag.UserTask = _repo.UserTask.ToList();

            ViewBag.Category = _repo.Category.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult UserTaskForm(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _repo.AddUserTask(userTask);
            }
            return View(userTask);
        }
    }
}
