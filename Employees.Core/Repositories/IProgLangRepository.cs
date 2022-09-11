using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IProgLangRepository
    {
        Task<IEnumerable<ProgLang>> GetAll();

        Task<int> Add(ProgLang progLang);

        Task<int> Update(ProgLang progLang);

        Task<int> Delete(ProgLang progLang);
    }
}
