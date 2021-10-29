using DataService.Abstract.Users;
using DataService.EntityData;
using DataService.EntityData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<User> CreateUsers(User user)
        {
            user.IsDisable = false;
            user.CreatedBy = 3;
            user.CreatedOn = DateTime.UtcNow;

            await _context.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            user.ChangedBy = null;
            user.ChangedOn = null;

            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUsersById(long id)
        {
            var res = await _context.Users
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return res;
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
