using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BusinessLogic
{
    public class PositionInCompanyService : IPositionInCompanyService
    {
        private readonly IPositionInCompanyRepository _repository;
        public PositionInCompanyService(IPositionInCompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(PositionInCompany progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(progLang.PositionName))
                throw new ArgumentNullException();
            var result = await _repository.Add(progLang);

            return result;

        }

        public async Task<int> Delete(PositionInCompany progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();

            var result = await _repository.Delete(progLang);

            return result;
        }

        public async Task<IEnumerable<PositionInCompany>> ReadAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Update(PositionInCompany progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(progLang.PositionName))
                throw new ArgumentNullException();
            var result = await _repository.Update(progLang);

            return result;
        }
    }
}
