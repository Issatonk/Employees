using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IProgLangService
    {
        Task<int> Create(ProgLang progLang);

        Task<IEnumerable<ProgLang>> ReadAll();

        Task<int> Update(ProgLang progLang);

        Task<int> Delete(ProgLang progLang);
    }
}
