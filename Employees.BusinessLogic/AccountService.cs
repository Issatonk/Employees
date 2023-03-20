using Employees.Core.Entity;
using Employees.Core.Helpers;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BusinessLogic
{


    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(User user)
        {
            if(string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException();
            }
            if (await _repository.Get(user.Login) is not null)
            {
                throw new ArgumentException("user is exist");
            }
            user.Salt = CryptoHelper.GetSalt();
            user.Password = CryptoHelper.GetHash(user.Password, user.Salt);


            await _repository.Add(user);

        }
        public async Task<User> Read(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("login is empty");
            }
            var result = await _repository.Get(login);

            return result;
        }

        public async Task<int> Update(string login, string password)
        {
            if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException();
            }
            var user = await _repository.Get(login);
            if (user is null)
            {
                throw new ArgumentException("user is not exist");
            }
            user.Salt = CryptoHelper.GetSalt();
            user.Password = CryptoHelper.GetHash(password, user.Salt);


            return await _repository.Update(user);
        }
        public async Task<int> Delete(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException("login is empty");
            return await _repository.Delete(login);
        }

        
    }
}
