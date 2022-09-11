using AutoMapper;
using Employees.Core;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Repositories
{
    public class ProgLangRepository : IProgLangRepository
    {
        private readonly EmployeesContext _context;
        private readonly IMapper _mapper;

        public ProgLangRepository(EmployeesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(ProgLang progLang)
        {
            var newProgLang = new Entities.ProgLang
            {
                Name = progLang.Name
            };
            await _context.AddAsync(newProgLang);
            await _context.SaveChangesAsync();

            return progLang.Id;
            
        }

        public async Task<int> Delete(ProgLang progLang)
        {
            _context.ProgLangs.Remove(new Entities.ProgLang { Id = progLang.Id });
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<ProgLang>> GetAll()
        {
            var progLangs = 
                await _context.ProgLangs.ToArrayAsync();
            return _mapper.Map<Entities.ProgLang[], Core.ProgLang[]>(progLangs);
        }

        public async Task<int> Update(ProgLang progLang)
        {
            _context.ProgLangs.Update(_mapper.Map<Core.ProgLang, Entities.ProgLang>(progLang));
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
