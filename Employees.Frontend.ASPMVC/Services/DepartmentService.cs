using Employees.Frontend.ASPMVC.Models;
using Employees.Frontend.ASPMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Services
{

    public class DepartmentService : IDepartmentService
    {
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            IEnumerable<Department> departments;
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri("https://localhost:44379/api/Department"));
                result.EnsureSuccessStatusCode();
                departments = await result.Content.ReadAsAsync<IEnumerable<Department>>();
            }
            return departments;
        }

        public async Task<Department> GetById(int departmentId)
        {
            var result = await GetDepartments();
            return result.ToList().Where(x=>x.Id == departmentId).First();
            
        }

    }

}
