﻿using DataService.Abstract.Users;
using Employee.Manager.Models;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.EntityData.EntityModels;

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
            var response = res
                .Select(x => UsersDTO.MapToDTO(x))
                .ToList();
            return response;
        }
        public async Task<bool> CreateUsers(UsersDTO usersDTO)
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

            usersDTO.UserPersonalDetails.UserId = user.Id;

            return true;

        }

    }
}
