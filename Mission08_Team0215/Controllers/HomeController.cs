using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0215.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            var userTask = ViewBag.UserTask;

            var category = ViewBag.Category;

            ViewBag.UserTask = _repo.UserTask.ToList();

            ViewBag.Category = _repo.Category.ToList();

            return View(userTask, category);
        }

        [HttpGet]
        public IActionResult UserTaskForm()
        {
            ViewBag.UserTask = _repo.UserTask.ToList();

            //ViewBag.Category = _repo.Category.ToList();

            //Trying to fix errors on line 45 of UserTaskForm.cshtml

            var categories = _repo.Category.ToList();

            ViewBag.Category = categories;

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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.UserTask
                .Single(x => x.TaskId == id);

            ViewBag.category = _repo.Category //ViewBag stores small amounts of data to transfer to Views
               .OrderBy(x => x.CategoryName)
               .ToList();

            //_context.SaveChanges();

            return View("UserTaskForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(UserTask UpdatedInfo)
        {
            _repo.Update(UpdatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrant");
        }

    }
}
