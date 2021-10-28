using DataService.EntityData.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Manager.Models.DTO.UserDTO
{
    public class UserPersonalDetailsDTO
    {
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }

        public static UserPersonalDetailsDTO MapToDTO(UserPersonalDetail userPersonalDetail)
        {
            var res = new UserPersonalDetailsDTO
            {
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
                Fname = userPersonalDetailsDTO.Fname,
                Mname = userPersonalDetailsDTO.Mname,
                Lname = userPersonalDetailsDTO.Lname,
                Dob = userPersonalDetailsDTO.Dob
            };
        }
        
      
    }
    
}
