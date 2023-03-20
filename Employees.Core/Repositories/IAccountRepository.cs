using System.Threading.Tasks;
using Employees.Core.Entity;

namespace Employees.Core.Repositories
{
    public interface IAccountRepository
    {
        Task<int> Add(User user);

        Task<User> Get(string login);
        Task<int> Update(User user);

        Task<int> Delete(string login);
    }
}
