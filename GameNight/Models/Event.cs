using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PlayedOn { get; set; }
        public string Location { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<UserEvent> Attendees { get; set; }
        public int OwnerId { get; set; }
        public bool Active { get; set; }
    }
}
