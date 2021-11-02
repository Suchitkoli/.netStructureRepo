
using DataService.Abstract.UserPersonalDetails;
using DataService.EntityData;
using DataService.EntityData.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
          
            userPersonalDetails.CreatedBy = 3;
            userPersonalDetails.CreatedOn = DateTime.UtcNow;
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

        public async Task<bool> DeleteUserPersonalDetails(long id)
        {
            var res = await _context.UserPersonalDetails
                .FirstOrDefaultAsync(e => e.Id == id);
            if (res != null)
            {
                _context.UserPersonalDetails.Remove(res);
                await _context.SaveChangesAsync();
                
            }
            return true;
        }

        public async Task<UserPersonalDetail> GetUserPersonalDetailsById(long Id)
        {
            var res = await _context.UserPersonalDetails
                .Where(x => x.Id == Id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return res;
        }

        public async Task<UserPersonalDetail> UpdateUserPersonalDetailsAsync(UserPersonalDetail userPersonalDetails)
        {

            _context.Update(userPersonalDetails);
            await _context.SaveChangesAsync();
            return userPersonalDetails;
        }
    }
}
