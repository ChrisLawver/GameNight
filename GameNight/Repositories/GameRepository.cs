using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(GameNightContext context) : base(context)
        {

        }
    }
}
