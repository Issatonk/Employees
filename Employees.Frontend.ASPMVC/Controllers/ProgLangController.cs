using Employees.Frontend.ASPMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Controllers
{
    public class ProgLangController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public async Task<IActionResult> Add(NewDepartment department)
        {
            using (var http = new HttpClient())
            {
                var json = HttpContext.Session.GetString("token");
                var token = JsonSerializer.Deserialize<Token>(json);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                var result = await http.PostAsJsonAsync(new Uri("https://localhost:44379/api/ProgLang"), department);
                result.EnsureSuccessStatusCode();
            }
            return RedirectToAction("ReadAll", "Employee");
        }
    }
}
