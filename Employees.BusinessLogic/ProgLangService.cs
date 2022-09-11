using Employees.Core;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BusinessLogic
{
    public class ProgLangService : IProgLangService
    {
        private readonly IProgLangRepository _repository;
        public ProgLangService(IProgLangRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(ProgLang progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(progLang.Name))
                throw new ArgumentNullException();
            var result = await _repository.Add(progLang);

            return result;

        }

        public async Task<int> Delete(ProgLang progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();

            var result = await _repository.Delete(progLang);

            return result;
        }

        public async Task<IEnumerable<ProgLang>> ReadAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> Update(ProgLang progLang)
        {
            if (progLang is null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(progLang.Name))
                throw new ArgumentNullException();
            var result = await _repository.Update(progLang);

            return result;
        }
    }
}
