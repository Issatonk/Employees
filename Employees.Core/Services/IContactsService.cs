using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IContactsService
    {
        Task<int> Update(Contacts contacts);
    }
}
