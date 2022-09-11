using Employees.Frontend.ASPMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            using (var http = new HttpClient())
            {
                var result = await http.PostAsJsonAsync(new Uri("https://localhost:44379/token"),model);
                
                if(!result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                result.EnsureSuccessStatusCode();
                var data = await result.Content.ReadAsAsync<Token>();
                HttpContext.Session.SetString("token",JsonSerializer.Serialize(data));
            }
            return RedirectToAction("ReadAll", "Employee");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            using (var http = new HttpClient())
            {
                var result = await http.PostAsJsonAsync(new Uri("https://localhost:44379/registration"), 
                    new {
                        Login= model.Login,
                        Password = model.Password,
                        DepartmentId = model.DepartmentId
                    });
                result.EnsureSuccessStatusCode();
                var data = await result.Content.ReadAsAsync<Token>();
                HttpContext.Session.SetString("token", JsonSerializer.Serialize(data));
            }
            return RedirectToAction("ReadAll", "Employee");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
