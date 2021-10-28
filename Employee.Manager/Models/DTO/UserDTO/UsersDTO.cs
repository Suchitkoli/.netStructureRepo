using DataService.EntityData.EntityModels;
using Employee.Manager.Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Manager.Models
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public static UsersDTO MapToDTO(User user)
        {
            var result = new UsersDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,

            };
            return result;
        }
        public static User MapToEntity(UsersDTO usersDTO)
        {
            return new User
            {
                Id = usersDTO.Id,
                Username = usersDTO.Username,
                Email = usersDTO.Email,
                FirstLoggedIn= DateTime.UtcNow,
                IsDisable=false,
                ChangedBy = null,
                ChangedOn = null,
                CreatedBy = 3,
                CreatedOn = DateTime.UtcNow

            };
        }





    }
}
