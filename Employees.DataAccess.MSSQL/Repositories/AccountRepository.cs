using AutoMapper;
using Employees.Core;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.DataAccess.MSSQL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmployeesContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(EmployeesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add(User user)
        {
            var newUser = _mapper.Map<Core.User, Entities.User>(user);
            newUser.Department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == user.Department.Id);
            _context.Users.Add(newUser);
            return await _context.SaveChangesAsync();
        }
        public async Task<User> Get(string login)
        {
            var user =  await _context
                .Users
                .Include(x=>x.Department)
                .FirstOrDefaultAsync(x => x.Login == login);
            return _mapper.Map<Entities.User, Core.User>(user);
        }

        public async Task<int> Update(User user)
        {
            _context.Users.Update(_mapper.Map<Core.User, Entities.User>(user));
            return await _context.SaveChangesAsync();
            
        }

        public async Task<int> Delete(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
            if (user.Role == "Admin")
                throw new ArgumentException();
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        
    }
}
