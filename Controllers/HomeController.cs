using Microsoft.AspNetCore.Mvc;
using MvcModelValidationApp.Models;
using System.Diagnostics;

namespace MvcModelValidationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserInfo(User user)
        {
            string result;
            if (ModelState.IsValid)
                result = $"User info: Name {user.Name}, Age {user.Age}";
            else
                result = "Non valid user data";

            result += $"\n";
            foreach (var item in ModelState)
            {
                foreach(var err in item.Value.Errors)
                    result += $"Key: {item.Key} = {err.ErrorMessage}\n";
            }
                

            return Content(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}