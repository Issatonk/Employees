using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IPositionInCompanyService
    {
        Task<int> Create(PositionInCompany progLang);

        Task<IEnumerable<PositionInCompany>> ReadAll();

        Task<int> Update(PositionInCompany progLang);

        Task<int> Delete(PositionInCompany progLang);
    }
}
