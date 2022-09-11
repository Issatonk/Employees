using Employees.Frontend.ASPMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetById(int departmentId);

    }
}
