using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class UserEvent
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        //Good place to put the score of a specific user on a specific game
        public bool IsWin { get; set; }
    }
}
