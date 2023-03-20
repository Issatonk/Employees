﻿using Employees.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IPositionInCompanyRepository
    {
        Task<IEnumerable<PositionInCompany>> GetAll();

        Task<int> Add(PositionInCompany progLang);

        Task<int> Update(PositionInCompany progLang);

        Task<int> Delete(PositionInCompany progLang);
    }
}
