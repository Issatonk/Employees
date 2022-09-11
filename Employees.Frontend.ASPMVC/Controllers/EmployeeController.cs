using Employees.Frontend.ASPMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet("Add")]
        public IActionResult AddEmployee(int? departmentId)
        {
            var json = HttpContext.Session.GetString("token");
            var token = JsonSerializer.Deserialize<Token>(json);
            ViewBag.DepartmentId = token.departmentId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewEmployee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmployee");
            }
            using(var http = new HttpClient())
            {
                var json = HttpContext.Session.GetString("token");
                var token = JsonSerializer.Deserialize<Token>(json);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                var result = await http.PostAsJsonAsync(new Uri("https://localhost:44379/api/Employee"), employee);

                result.EnsureSuccessStatusCode();
            }
            return RedirectToAction("ReadAll");
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll(int page = 1, int size = 100)
        {
            PageEmployees employees = null; 
            using(var http = new HttpClient())
            {
                var json = HttpContext.Session.GetString("token");
                var token = JsonSerializer.Deserialize<Token>(json);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                ViewBag.Role = token.role;
                HttpResponseMessage result;
                if (token.departmentId == null)
                {
                     result = await http.GetAsync($"https://localhost:44379/api/Employee/GetPage?Page={page}&size={size}");
                }
                else
                {
                    result = await http.GetAsync($"https://localhost:44379/api/Employee/GetPage?Page={page}&size={size}&departmentId={token.departmentId}");
                }
                result.EnsureSuccessStatusCode();
                employees = await result.Content.ReadAsAsync<PageEmployees>();
                
            }
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using(var http = new HttpClient())
            {
                var json = HttpContext.Session.GetString("token");
                var token = JsonSerializer.Deserialize<Token>(json);
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                HttpResponseMessage result;
                if (id != 0)
                {
                    result = await http.DeleteAsync($"https://localhost:44379/api/Employee?employeeId={id}");
                    result.EnsureSuccessStatusCode();
                }
            }
            return RedirectToAction("ReadAll");
        }
        
    }
}
