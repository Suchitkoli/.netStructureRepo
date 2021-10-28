using System;
using System.Collections.Generic;

#nullable disable

namespace DataService.EntityData.EntityModels
{
    public partial class UserMessageType
    {
        public UserMessageType()
        {
            UserMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
