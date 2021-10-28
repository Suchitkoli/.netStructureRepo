
using DataService.Abstract.UserPersonalDetails;
using DataService.EntityData;
using DataService.EntityData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services.UserPersonalDetails
{
   public class UserPersonalDetailsService : IUserPersonalDetailsServices
    { 
        private EmployeeUserContext _context;

        public UserPersonalDetailsService(EmployeeUserContext employeeUserContext)
        {
            _context = employeeUserContext;
        }

        public async Task<bool> CreateUsersPersonalDetails(UserPersonalDetail userPersonalDetails)
        {
            await _context.AddAsync<UserPersonalDetail>(userPersonalDetails);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<UserPersonalDetail>> GetUsersPersonalDetails()
        {
            var res = await _context.UserPersonalDetails
                .AsNoTracking()
                .ToListAsync();

            return res;
        }
    }
}
