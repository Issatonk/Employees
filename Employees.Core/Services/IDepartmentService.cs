using Employees.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IDepartmentService
    {
        Task Create(Department department);

        Task<IEnumerable<Department>> ReadAll();

        Task<int> Update(Department department);

        Task<int> Delete(Department department);
    }
}
