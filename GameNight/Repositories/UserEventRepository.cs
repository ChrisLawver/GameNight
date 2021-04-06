using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public class UserEventRepository : Repository<UserEvent>, IRepository<UserEvent>
    {
        public UserEventRepository(GameNightContext context) : base(context)
        {

        }
    }
}
