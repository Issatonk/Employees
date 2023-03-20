using AutoMapper;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Employee employee)
        {
            
            var newEmployee = _mapper.Map<Core.Entity.Employee, Entities.Employee>(employee);
            newEmployee.Department = _context.Departments.FirstOrDefault(x=>x.Id == newEmployee.Department.Id);
            newEmployee.Position = _context.PositionInCompany.FirstOrDefault(x => x.Id == newEmployee.Position.Id);

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.Id;
        }

        public async Task<int> Delete(Employee employee)
        {
            _context.Employees.Remove(new Entities.Employee { Id = employee.Id });
            var result = await _context.SaveChangesAsync();
            return result;

        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees
                .Include(x=>x.Department)
                .Include(x=>x.Position)
                .ToArrayAsync();
            return _mapper.Map<Entities.Employee[], Core.Entity.Employee[]>(employees);
        }

        public async Task<IEnumerable<Employee>> GetByDepartment(Department department)
        {
            var result = await _context.Employees.Where(x => x.Department.Id == department.Id)
                .Include(x=>x.Position)
                .ToArrayAsync();
            return _mapper.Map<Entities.Employee[], Core.Entity.Employee[]>(result);
        }

        public async Task<(IEnumerable<Employee>, int numberOfPages)> GetPage(int page, int size, int? departmentId)
        {
            var allEmployees =  _context.Employees as IQueryable<Entities.Employee>;
            if(departmentId != null) 
            {
                 allEmployees = allEmployees.Where(x=>x.Department.Id == departmentId);
            }
            var employees = await allEmployees
                .Skip((page - 1) * size)
                .Take(size)
                .Include(x => x.Department)
                .Include(x => x.Position)
                .ToArrayAsync();
            int numberOfPages = 0;
            if (departmentId is null)
            {
                numberOfPages = (int)Math.Ceiling(await _context.Employees.CountAsync() / (double)size);
            }
            else
            {
                numberOfPages = (int)Math.Ceiling(await _context.Employees.CountAsync(x => x.Department.Id == departmentId) / (double)size);
            }

            return (
                _mapper.Map<Entities.Employee[], Core.Entity.Employee[]>(employees), 
                numberOfPages
                );
        }

        public async Task<int> Update(Employee employee)
        {
            var modifiedEmployee = _mapper.Map<Core.Entity.Employee, Entities.Employee>(employee);

            modifiedEmployee.Department = _context.Departments.FirstOrDefault(x => x.Id == employee.Department.Id);
            modifiedEmployee.Position = _context.PositionInCompany.FirstOrDefault(x => x.Id == employee.Position.Id);

            _context.Employees.Update(modifiedEmployee);
            await _context.SaveChangesAsync();

            return modifiedEmployee.Id;
        }
    }
}
