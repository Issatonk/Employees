using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<int> Add(Employee employee);

        Task<int> Update(Employee employee);

        Task<int> Delete(Employee employee);

        Task<IEnumerable<Employee>> GetByDepartment(Department department);

        public Task<(IEnumerable<Employee>, int numberOfPages)> GetPage(int page, int size, int? departmentId);
    }
}
