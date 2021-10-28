using DataService.Abstract.Users;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Manager.Managers.Users
{
    public class UsersManager
    {
        private readonly IUserDataService _usersDataService;

        public UsersManager(IUserDataService userDataService)
        {
            _usersDataService = userDataService;
        }
        public async Task<List<UsersDTO>> GetUsers()
        {
            var res = await _usersDataService.GetUsers();
            var response= res
                .Select(x => UsersDTO.MapToDTO(x))
                .ToList();
            return response;
        }
        public async Task<bool> CreateUsers(UsersDTO users)
        {
            return await _usersDataService.CreateUsers(UsersDTO.MapToEntity(users));
        }

    }
}
