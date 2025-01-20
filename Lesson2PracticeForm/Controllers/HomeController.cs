using System;
using Lesson2PracticeForm.Entities;
using Lesson2PracticeForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Lesson2PracticeForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public IActionResult Add()
        {
            var user = new UserAddViewModel
            {
                User = new User()
            };
            return View(user);
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Helpers","User.json");

            var jsonData = System.IO.File.ReadAllText(filePath);
            var user = JsonSerializer.Deserialize<List<User>>(jsonData);
            return View(user);
        }

        public IActionResult WriteJson(User user)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "User.json");

            List<User> users;
            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
            }
            else
            {
                users = new List<User>();
            }
            users.Add(user);
            string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, jsonString);

            return RedirectToAction("Index");
        }
    }
}
