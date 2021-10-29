using Employee.Manager.Managers.UserPersonalDetails;
using Employee.Manager.Models.DTO;
using Employee.Manager.Models.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Controllers.UserPersonalDetails
{
    [Route("UserPersonalDetails")]
    public class UserPersonalDetailsController : Controller
    {
         private readonly UserPersonalDetailsManager _userPersonalDetailsManager;

         public UserPersonalDetailsController(UserPersonalDetailsManager userPersonalDetailsManager)
         {
                _userPersonalDetailsManager = userPersonalDetailsManager;
         }
        

        [HttpGet]
        public async Task<List<UserPersonalDetailsDTO>> GetUsersPersonalDetails()
        {
            var result = await _userPersonalDetailsManager.GetUsersPersonalDetails();
            return result;
        }

        [HttpPut]
        public async Task<bool> CreateCreateUsers(UserPersonalDetailsDTO usersDTO)
        {
            var res = await _userPersonalDetailsManager.CreateUsersPersonalDetails(usersDTO);
            return res;
        }
    }
}
