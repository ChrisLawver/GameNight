using GameNight.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameNight.Extensions;
using GameNight.Helpers;

namespace GameNight.Repositories
{
    public class Repository<T> where T : class
    {
        private DbContext db;

        public Repository(DbContext db)
        {
            this.db = db;
        }

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return db.Set<Game>().ToList();
        }

        public Game GetByExternalId(string externalId)
        {
            var game = db.Set<Game>().Where(g => g.ExternalId == externalId).FirstOrDefault();

            return game;
        }

        public List<Game> PopulateGameList()
        {
            var games = db.Set<Game>().ToList();

            return games;
        }

        public List<User> PopulateUserList()
        {
            var users = db.Set<User>().ToList();

            return users;
        }

        public LoginResult CheckLogin(string username, string password)
        {
            var user = db.Set<User>().Where(u => u.Username == username && u.Password == Helpers.Helper.EncryptPassword(password)).FirstOrDefault();
            if(user == null)
            {
                return new LoginResult()
                {
                    Result = false,
                    Message = "No user found",
                    User = null
                };
            }
            else
            {
                return new LoginResult() 
                { 
                    Result = true, 
                    Message = "", 
                    User = user
                };
            }
        }

        public bool CheckDuplicateUser(string username)
        {
            var user = db.Set<User>().Where(u => u.Username == username).FirstOrDefault();
            if(user == null)
            {
                return false;
            }
            
            return true;

        }

        public bool CheckDuplicateUserEvent(int userId, int eventId)
        {
            var user = db.Set<UserEvent>().Where(u => u.UserId == userId && u.EventId == eventId).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            return true;

        }

        public bool CheckDuplicateUserGame(int userId, int gameId)
        {
            var user = db.Set<UserGame>().Where(u => u.UserId == userId && u.GameId == gameId).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            return true;

        }
    }
}
