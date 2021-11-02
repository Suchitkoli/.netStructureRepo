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
     [ApiController]
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

        [HttpGet("{id}")]
        public async Task<UserPersonalDetailsDTO> GetUserPersonalDetailsById(long id)
        {
            var result = await _userPersonalDetailsManager.GetUserPersonalDetailsById(id);
            return result;
        }

        [HttpPut]
        public async Task<UserPersonalDetailsDTO> CreateUsersPersonalDetails(UserPersonalDetailsDTO usersDTO)
        {
            var res = await _userPersonalDetailsManager.CreateUsersPersonalDetails(usersDTO);
            return res;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUserPersonalDetails(long id)
        {
            var res = await _userPersonalDetailsManager.DeleteUserPersonalDetails(id);
            return res;

        }
    }
}
