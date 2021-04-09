using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Extensions
{
    public interface IAccount
    {
        LoginResult CheckLogin(string username, string password);

    }
    public class LoginResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
