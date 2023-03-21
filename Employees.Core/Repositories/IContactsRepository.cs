using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IContactsRepository
    {
        Task Create(Contacts contacts);

        Task<IEnumerable<Contacts>> ReadByEmployee(int employeeId);

        Task<int> Update(Contacts contacts);

        Task<int> Delete(Contacts contacts);
    }
}
