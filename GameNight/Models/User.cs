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
        private double winPercent;
 
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
                if(this.Events != null)
                {
                return this.Events.Where(e => e.IsWin == true).Count();
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                win = this.Events.Count();
            }
        }
        public int Lose
        {
            get
            {
                if (this.Events != null)
                {
                    return this.Events.Count()- Win;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                lose = this.Events.Count();
                
            }
        }

        public double WinPercent
        {
            get
            {
                if (this.Events != null && this.Events.Count() > 0)
                {
                    return Math.Round(Convert.ToDouble(this.Win) / Convert.ToDouble(this.Events.Count()) * 100, 2);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                winPercent = value;
            }
        }

        public virtual ICollection<UserEvent> Events { get; set; }
        //User.Events
        public virtual ICollection<UserGame> Games { get; set; }
    }
}
