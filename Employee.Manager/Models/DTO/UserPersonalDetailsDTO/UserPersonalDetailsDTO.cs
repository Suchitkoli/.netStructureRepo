using DataService.EntityData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Manager.Models.DTO.UserDTO
{
    public class UserPersonalDetailsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }

        public static UserPersonalDetailsDTO MapToDTO(UserPersonalDetail userPersonalDetail)
        {
            var res = new UserPersonalDetailsDTO
            {
                Id = userPersonalDetail.Id,
                UserId = userPersonalDetail.UserId,
                Fname = userPersonalDetail.Fname,
                Mname = userPersonalDetail.Mname,
                Lname = userPersonalDetail.Lname,
                Dob = userPersonalDetail.Dob
            };
            return res;
        }
        public static UserPersonalDetail MapToEntity(UserPersonalDetailsDTO userPersonalDetailsDTO)
        {
            return new UserPersonalDetail
            {
                UserId=userPersonalDetailsDTO.UserId,
                Fname = userPersonalDetailsDTO.Fname,
                Mname = userPersonalDetailsDTO.Mname,
                Lname = userPersonalDetailsDTO.Lname,
                Dob = userPersonalDetailsDTO.Dob
            };
        }
        
      
    }
    
}
