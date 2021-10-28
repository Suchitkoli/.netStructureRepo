using System;
using System.Collections.Generic;

#nullable disable

namespace DataService.EntityData.EntityModels
{
    public partial class UserPersonalDetail
    {
        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public int? EmpId { get; set; }
        public DateTime? RejectedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual User User { get; set; }
    }
}
