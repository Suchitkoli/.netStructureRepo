using System;
using System.Collections.Generic;

#nullable disable

namespace DataService.EntityData.EntityModels
{
    public partial class UserMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int TypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual UserMessageType Type { get; set; }
        public virtual User User { get; set; }
    }
}
