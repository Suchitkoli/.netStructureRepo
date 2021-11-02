using DataService.EntityData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Abstract.Users
{
    public interface IUserDataService
    {
        Task<User> GetUsersById(long id);
        Task<List<User>> GetUsers();

        Task<User> CreateUsers(User user);
        Task<User> UpdateUserAsync(User user);

        Task<bool> DeleteUser(long id);
    }
}
