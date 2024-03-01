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
            ViewBag.UserTask = _repo.UserTask.ToList();

            ViewBag.Category = _repo.Category.ToList();

            var userTask = ViewBag.UserTask;

            var category = ViewBag.Category;

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

            return View(new UserTask());
        }

        [HttpPost]
        public IActionResult UserTaskForm(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _repo.AddUserTask(userTask);
                return RedirectToAction("Quadrant");
            }
            else
            {
                return View(userTask);
            }
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
            if (ModelState.IsValid)
            {
                _repo.EditUserTask(UpdatedInfo);
                return RedirectToAction("Quadrant");
            }
            else
            {
                return View(UpdatedInfo);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.recordToDelete = _repo.UserTask
                .Single(x => x.TaskId == id);

            return View("ConfirmDelete");
        }

        [HttpPost]
        public IActionResult Delete(UserTask record)
        {
            _repo.DeleteUserTask(record);
            return RedirectToAction("Quadrant");
        }

    }
}
