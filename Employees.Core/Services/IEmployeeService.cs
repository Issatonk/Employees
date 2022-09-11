using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IEmployeeService
    {
        Task<int> Create(Employee employee);

        Task<IEnumerable<Employee>> GetAll();

        Task<int> Update(Employee employee);

        Task<int> Delete(Employee employee);

        Task<IEnumerable<Employee>> GetByDepartment(Department department);

        public Task<(IEnumerable<Employee>, int numberOfPages)> GetPage(int page, int size, int? departmentId);
    }
}
