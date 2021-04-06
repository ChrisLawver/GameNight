using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(GameNightContext context) : base(context)
        {

        }
    }
}
