using DataService.Abstract.Users;
using DataService.EntityData;
using DataService.EntityData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.Users
{

    public class UsersDataService : IUserDataService
    {
        private EmployeeUserContext _context;

        public UsersDataService(EmployeeUserContext employeeUserContext)
        {
            _context = employeeUserContext;
        }

        public async Task<bool> CreateUsers(User user)
        {
            await _context.AddAsync<User>(user);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<User>> GetUsers()
        {
            var res = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            return res;
        }
    }
}
