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
        public UserPersonalDetailsDTO UserPersonalDetails { get; set; }

        public static UsersDTO MapToDTO(User user)
        {
            var result = new UsersDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email, 
            };

            if (user.UserPersonalDetail != null)
            {
                result.UserPersonalDetails = UserPersonalDetailsDTO.MapToDTO(user.UserPersonalDetail);
            }

            return result;
        }
    }
}
