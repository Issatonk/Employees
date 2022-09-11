using Employees.Core;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException();
            if(employee.Name == string.Empty || employee.Surname == string.Empty)
                throw new ArgumentException();
            await _repository.Add(employee);

            return employee.Id;
        }

        public async Task<int> Delete(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException();
            await _repository.Delete(employee);

            return employee.Id;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Employee>> GetByDepartment(Department department)
        {
            if (department.Id <= default(int))
                throw new ArgumentException("department is not exist");
            return await _repository.GetByDepartment(department);
        }

        public async Task<(IEnumerable<Employee>, int numberOfPages)> GetPage(int page, int size, int? departmentId)
        {
            if (page <= 0 || size <= 0)
                throw new ArgumentException("page or size less than or equal 0");
            
            return await _repository.GetPage(page, size, departmentId);
        }

        public async Task<int> Update(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException();
            if (employee.Name == string.Empty || employee.Surname == string.Empty || employee.Id <= default(int))
                throw new ArgumentException();
            await _repository.Update(employee);

            return employee.Id;
        }
    }
}
