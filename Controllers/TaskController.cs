using DeploymentTask3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DeploymentTask3.Controllers
{
    public class TasksController : Controller
    {
        private static List<Tasks> _tasks = new List<Tasks>();
        private static int _nextId = 1;
        public IActionResult Index()
        {
            return View(_tasks);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tasks task)
        {
            if (!string.IsNullOrWhiteSpace(task.Description))
            {
                task.Id = _nextId++;
                _tasks.Add(task);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
