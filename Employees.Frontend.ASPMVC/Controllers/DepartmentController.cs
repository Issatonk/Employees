using Employees.Frontend.ASPMVC.Models;
using Employees.Frontend.ASPMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

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
                var result = await http.PostAsJsonAsync(new Uri("https://localhost:44379/api/Department"), department);
                result.EnsureSuccessStatusCode();
            }
            return RedirectToAction("ReadAll", "Employee");
        }
    }
}
