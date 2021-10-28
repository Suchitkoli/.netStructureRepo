using DataService.EntityData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Abstract.Users
{
    public interface IUserDataService
    {
        Task<List<User>> GetUsers();

        Task<bool> CreateUsers(User user);
    }
}
