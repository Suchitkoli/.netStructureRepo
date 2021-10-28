using DataService.Abstract.UserPersonalDetails;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Manager.Managers.UserPersonalDetails
{
   
    public class UserPersonalDetailsManager
    {
        private readonly IUserPersonalDetailsServices _userPersonalDetailsServices;
        public UserPersonalDetailsManager(IUserPersonalDetailsServices userPersonalDetailsServices )
        {
            _userPersonalDetailsServices = userPersonalDetailsServices;
        }
        public async Task<List<UserPersonalDetailsDTO>> GetUsersPersonalDetails()
        {
            var res = await _userPersonalDetailsServices.GetUsersPersonalDetails();
            var response = res
                .Select(x => UserPersonalDetailsDTO.MapToDTO(x))
                .ToList();
            return response;
        }
    }
}
