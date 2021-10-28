using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Manager.Models.DTO.UserDTO
{
    public class CreateUserDTO
    {
        public string username { get; set; }
        public string email { get; set; }
        public bool isDisable { get; set; }
        public  DateTime createdOn { get; set; }
        public int createdBy { get; set; }

    }
}
