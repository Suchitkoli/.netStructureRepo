
using System;
using System.Collections.Generic;


namespace DataService.EntityData.EntityModels
{
    public partial class Employee
    {
        public int Employeeid { get; set; }
        public string Email { get; set; }
        public int? Userid { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User User { get; set; }
    }
}
