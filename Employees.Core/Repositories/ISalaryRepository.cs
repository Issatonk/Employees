using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface ISalaryRepository
    {
        Task CalculateSalary(Salary salary);

        Task<IEnumerable<Salary>> ReadByEmployee(int employeeId);

        Task<int> Update(Salary salary);

        Task<int> Delete(Salary salary);
    }
}
