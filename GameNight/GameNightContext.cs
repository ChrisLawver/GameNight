using GameNight.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight
{
    public class GameNightContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=GameNightDB;Trusted_Connection=True";

            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "mario",
                    Password = "password",
                    ProfilePic = "https://cdn.vox-cdn.com/thumbor/QyaLYNjgXHUP4aQjxDsyG_Gw9w0=/0x0:1700x960/1075x1075/filters:focal(714x344:986x616):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/57514059/mario.0.jpg",
                    Location = "Mushroom Kingdom"
                },
                new User()
                {
                    Id = 2,
                    Username = "luigi",
                    Password = "password2",
                    ProfilePic = "https://play.nintendo.com/images/Masthead_luigi.17345b1513ac044897cfc243542899dce541e8dc.9afde10b.png",
                    Location = "Mushroom Kingdom"
                }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game()
                {
                    Id = 1,
                    Title = "Chess"
                },
                new Game()
                {
                    Id = 2,
                    Title = "Checkers"
                }
                );
            modelBuilder.Entity<Event>().HasData(
                new Event()
                {
                    Id = 1,
                    Name = "Tournament",
                    PlayedOn = DateTime.Now,
                    Location = "16-Bit",
                    GameId = 1
                }
                );
            modelBuilder.Entity<UserEvent>().HasData(
                new UserEvent()
                {
                    Id = 1,
                    EventId = 1,
                    UserId = 1,
                    IsWin = true
                },
                new UserEvent()
                {
                    Id = 2,
                    EventId = 1,
                    UserId = 2,
                    IsWin = false
                }
                );
            modelBuilder.Entity<UserGame>().HasData(
                new UserGame()
                {
                    Id = 1,
                    UserId = 1,
                    GameId = 1
                },
                new UserGame()
                {
                    Id = 2,
                    UserId = 2,
                    GameId = 1
                }
                );
        }
    }
}
