using Employee.Manager.Managers.Users;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication5.Controllers.User
{
    [Route("Users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UsersManager _usersManager;
       
        public UserController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }

       [HttpGet]
       public async Task<List<UsersDTO>> GetUsers()
       {
            var result = await _usersManager.GetUsers();
            return result;
       }

        [HttpGet("{id}")]
        public async Task<UsersDTO> GetUsersById(long id)
        {
            var result = await _usersManager.GetUsersByID(id);
            return result;
        }
        [HttpPut]
        public async Task<UsersDTO> CreateCreateUsers(UsersDTO usersDTO)
        {
             var res = await _usersManager.CreateUsers(usersDTO);
            return res;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(long id)
        {
            var res = await _usersManager.DeleteUser(id);
            return res;

        }

    }
}
