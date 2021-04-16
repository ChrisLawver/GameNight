using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GameNight.Helpers;

namespace GameNight.Models
{
    public class User
    {
        private string _password;
        private int win;
        private int lose;
 
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
        [RegularExpression("([^\\s]+(\\.(?i)(jpg|png|gif|bmp))$)")]
        public string ProfilePic { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public int Win
        {
            get
            {
                return win;
            }
            set
            {
                
                win = this.Events.Where(e => e.IsWin == true).Count();
            }
        }
        public int Lose
        {
            get
            {
                return lose;
            }
            set
            {
                lose = this.Events.Where(e => e.IsWin == false).Count();
                
            }
        }

        public virtual ICollection<UserEvent> Events { get; set; }
        //User.Events
        public virtual ICollection<UserGame> Games { get; set; }
    }
}
