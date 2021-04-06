﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        
    }
}
