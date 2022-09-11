using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();

        Task<int> Add(Department department);

        Task<int> Update(Department department);

        Task<int> Delete(Department department);
    }
}
