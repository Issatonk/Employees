﻿using System.Security.Claims;
using System.Threading.Tasks;
using Employees.Core.Entity;

namespace Employees.Core.Services
{
    public interface IAccountService
    {
        Task Create(User user);

        Task<User> Read(string login);
        
        Task<int> Update(string login, string password);

        Task<int> Delete(string login);

        

    }
}
