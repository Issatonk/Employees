using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeesContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(EmployeesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(Department department)
        {
            var newDep = _mapper.Map<Core.Entity.Department, Entities.Department>(department);

            await _context.Departments.AddAsync(newDep);

            return await _context.SaveChangesAsync();

            
        }

        public async Task<int> Delete(Department department)
        {
            var result =  _context.Departments.Remove(
                 _mapper.Map<Core.Entity.Department, Entities.Department>(department)
                );
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            ICollection<Department> departments = new List<Department>();

            var result = await _context.Departments
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Entities.Department[],Core.Entity.Department[]>(result);
        }

        public async Task<int> Update(Department department)
        {
            var dep = _mapper.Map<Core.Entity.Department, Entities.Department>(department);
            _context.Departments.Update(dep);
            var result = await _context.SaveChangesAsync();
            return result;

        }
    }
}
