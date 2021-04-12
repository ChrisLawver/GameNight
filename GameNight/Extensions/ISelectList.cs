﻿using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Extensions
{
    public interface ISelectList
    {
        IEnumerable<Game> GetAllGames();
        Game GetByExternalId(string externalId);
        List<Game> PopulateGameList();
    }
}
