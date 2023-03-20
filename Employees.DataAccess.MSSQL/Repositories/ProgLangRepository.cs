using AutoMapper;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Repositories
{
    public class PositionInCompanyRepository : IPositionInCompanyRepository
    {
        private readonly EmployeesContext _context;
        private readonly IMapper _mapper;

        public PositionInCompanyRepository(EmployeesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(PositionInCompany progLang)
        {
            var newProgLang = new Entities.PositionInCompany
            {
                Name = progLang.PositionName
            };
            await _context.AddAsync(newProgLang);
            await _context.SaveChangesAsync();

            return progLang.Id;
            
        }

        public async Task<int> Delete(PositionInCompany progLang)
        {
            _context.PositionInCompany.Remove(new Entities.PositionInCompany { Id = progLang.Id });
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<PositionInCompany>> GetAll()
        {
            var progLangs = 
                await _context.PositionInCompany.ToArrayAsync();
            return _mapper.Map<Entities.PositionInCompany[], Core.Entity.PositionInCompany[]>(progLangs);
        }

        public async Task<int> Update(PositionInCompany progLang)
        {
            _context.PositionInCompany.Update(_mapper.Map<Core.Entity.PositionInCompany, Entities.PositionInCompany>(progLang));
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
