using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Extensions
{
    public interface ISelectList
    {
        IEnumerable<Game> GetAllGames();
        List<User> PopulateUserList();
        List<Game> PopulateGameList();
    }
}
