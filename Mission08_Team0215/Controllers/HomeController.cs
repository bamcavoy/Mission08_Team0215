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

            return View();
        }

        [HttpGet]
        public IActionResult UserTaskForm()
        {
            ViewBag.UserTask = _repo.UserTask.ToList();

            ViewBag.Category = _repo.Category.ToList();

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
                ViewBag.UserTask = _repo.UserTask.ToList();

                ViewBag.Category = _repo.Category.ToList();

                return View();
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
                .SingleOrDefault(x => x.TaskId == id);
            return View("ConfirmDelete");
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteUserTask(id);
            return RedirectToAction("Quadrant");
        }

    }
}
