using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public class EventRepository : Repository<Event>, IRepository<Event>
    {
        public EventRepository(GameNightContext context) : base(context)
        {

        }
    }
}
