using Employees.Frontend.ASPMVC.Models;
using Employees.Frontend.ASPMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Frontend.ASPMVC.Services
{
    public class ProgLangService : IProgLangService
    {
        public async Task<IEnumerable<ProgLang>> GetProgLangs()
        {
            IEnumerable<ProgLang> progLangs;
            using (var http = new HttpClient())
            {
                var result = await http.GetAsync(new Uri("https://localhost:44379/api/ProgLang"));
                result.EnsureSuccessStatusCode();
                progLangs = await result.Content.ReadAsAsync<IEnumerable<ProgLang>>();
            }
            return progLangs;
        }
    }

}
