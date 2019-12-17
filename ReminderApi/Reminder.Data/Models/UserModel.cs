using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Reminder.Data.Core;

namespace Reminder.Data.Models
{
    public class UserModel : IdentityUser, IEntity<string>
    {
        public UserModel()
        {
            Notes = new List<Note>();
        }

        public byte[] Password { get; set; }
        public byte[] ImageContent { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}