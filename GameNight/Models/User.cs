using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GameNight.Helper;

namespace GameNight.Models
{
    public class User
    {
        private string _password;
 
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                _password = Helper.EncryptPassword(value);
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<UserEvent> Events { get; set; }
        //User.Events
        public virtual ICollection<UserGame> Games { get; set; }
    }
}
