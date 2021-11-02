using DataService.Abstract.Users;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.EntityData.EntityModels;
using Employee.Manager.Managers.UserPersonalDetails;

namespace Employee.Manager.Managers.Users
{
    public class UsersManager
    {
        private readonly IUserDataService _usersDataService;

        private readonly UserPersonalDetailsManager _userPersonalDetailsManager;

        public UsersManager(IUserDataService userDataService,UserPersonalDetailsManager userPersonalDetailsManager)
        {
            _usersDataService = userDataService;
            _userPersonalDetailsManager = userPersonalDetailsManager;
        }

        public async Task<List<UsersDTO>> GetUsers()
        {
            var res = await _usersDataService.GetUsers();
            var response = res
                .Select(x => UsersDTO.MapToDTO(x))
                .ToList();
            return response;
        }
        
        public async Task<bool> DeleteUser(long id)
        {

            var res = await _usersDataService.DeleteUser(id);

            return res;
        }

        public async Task<UsersDTO>GetUsersByID(long id)
        {
            var res = await _usersDataService.GetUsersById(id);
            return UsersDTO.MapToDTO(res);
        }
        public async Task<UsersDTO> CreateUsers(UsersDTO usersDTO)
        {
            var isNew = usersDTO.Id == 0;

            var user = new User();

            if (!isNew)
            {
                user = await _usersDataService.GetUsersById(usersDTO.Id);

            }

            user.Username = usersDTO.Username;
            user.Email = usersDTO.Email;
            user.FirstLoggedIn = DateTime.UtcNow;

            
            if (isNew)
            {
                 await _usersDataService.CreateUsers(user);
            }
            else
            {
                await _usersDataService.UpdateUserAsync(user);
            }
            if (usersDTO.UserPersonalDetails != null) {
                usersDTO.UserPersonalDetails.UserId = user.Id;
                await _userPersonalDetailsManager.CreateUsersPersonalDetails(usersDTO.UserPersonalDetails);
              
            }
            
            return UsersDTO.MapToDTO(user);

        }

    }
}
