using Employees.Frontend.ASPMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Services.Interfaces
{
    public interface IProgLangService
    {
        Task<IEnumerable<ProgLang>> GetProgLangs();
    }
}
