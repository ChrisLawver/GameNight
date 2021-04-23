using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public class UserGameRepository : Repository<UserGame>, IRepository<UserGame>
    {
        public UserGameRepository(GameNightContext context) : base(context)
        {

        }
    }

}
