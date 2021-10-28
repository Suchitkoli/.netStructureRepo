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
    [HttpPost]
        public async Task<bool> CreateCreateUsers(UsersDTO usersDTO)
        {
            var res = await _usersManager.CreateUsers(usersDTO);
            return res;
        }
    }
}
