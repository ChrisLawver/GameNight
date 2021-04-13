using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Extensions
{
    public interface IUtility
    {
        bool CheckDuplicateUserEvent(int userId, int eventId);
        bool CheckDuplicateUserGame(int userId, int gameId);
        Game GetByExternalId(string externalId);
        bool CheckMaxPlayers(int maxPlayers, IEnumerable<UserEvent> attendees);
        Event GetEventById(int id);
    }
}
