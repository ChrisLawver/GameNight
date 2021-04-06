using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public string Location { get; set; }

        public virtual ICollection<UserEvent> Events { get; set; }
        //User.Events
        public virtual ICollection<UserGame> Games { get; set; }
    }
}
