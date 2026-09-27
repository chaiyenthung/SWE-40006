using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task3.Models; 

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        // In-memory list 
        private static List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Provision Azure App Service", Status = "Completed", CreatedBy = "105025228", CreatedAt = DateTime.Now.AddMinutes(-30) },
            new TaskItem { Id = 2, Title = "Deploy ASP.NET C# Application", Status = "In Progress", CreatedBy = "105025228", CreatedAt = DateTime.Now.AddMinutes(-10) },
            new TaskItem { Id = 3, Title = "Deactivate App for Task 3.2 Rubric", Status = "Pending", CreatedBy = "105025228", CreatedAt = DateTime.Now }
        };

  
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.StudentID = "105025228";
            ViewBag.ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View(_tasks);
        }

        [HttpPost]
        public ActionResult AddTask(string taskTitle)
        {
            if (!string.IsNullOrWhiteSpace(taskTitle))
            {
                int nextId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
                _tasks.Add(new TaskItem
                {
                    Id = nextId,
                    Title = taskTitle,
                    Status = "Pending",
                    CreatedBy = "105025228",
                    CreatedAt = DateTime.Now
                });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeStatus(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                if (task.Status == "Pending")
                    task.Status = "In Progress";
                else if (task.Status == "In Progress")
                    task.Status = "Completed";
                else
                    task.Status = "Pending";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}