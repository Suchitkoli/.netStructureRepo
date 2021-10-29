using System;
using System.Collections.Generic;

#nullable disable

namespace DataService.EntityData.EntityModels
{
    public partial class User
    {
        public User()
        {
            UserMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? FirstLoggedIn { get; set; }
        public bool IsDisable { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual UserPersonalDetail UserPersonalDetail { get; set; }
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
