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
        public IActionResult Add()
        {

        }
        
    }
}
