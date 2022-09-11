using Employees.Core;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BusinessLogic
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Department department)
        {
            if (department is null)
                throw new ArgumentNullException();
            if (department.Name == string.Empty || department.Floor <= 0)
                throw new ArgumentException();
            await _repository.Add(department);
        }

        public async Task<int> Delete(Department department)
        {
            if (department is null)
                throw new ArgumentNullException();
            await _repository.Delete(department);
            return department.Id;
        }

        public async Task<IEnumerable<Department>> ReadAll()
        {
            return  await _repository.GetAll();

        }

        public async Task<int> Update(Department department)
        {
            if (department is null)
                throw new ArgumentNullException();
            if (department.Name == string.Empty || department.Floor <= 0)
                throw new ArgumentException();
            await _repository.Update(department);
            return department.Id;
        }
    }
}
