using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ExternalId { get; set; }

        public string Image { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Description { get; set; }


        public virtual ICollection<UserGame> Players { get; set; }
        //Game.Players.User.Username

        public virtual ICollection<Event> Events { get; set; }
    }
}
