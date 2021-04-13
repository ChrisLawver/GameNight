using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Controllers
{
    public class UserGameController : Controller
    {

        IRepository<UserGame> userGameRepo;


        public UserGameController(IRepository<UserGame> userGame)
        {
            this.userGameRepo = userGame;
        }

        public ViewResult Index()
        {
            return View(userGameRepo.GetAll());
        }

        public ViewResult Create(int userId)
        {
            var games = userGameRepo.PopulateGameList();

            ViewBag.GameId = games;

            return View(new UserGame() { UserId = userId, Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(UserGame model)
        {
            var games = userGameRepo.PopulateGameList();
            ViewBag.GameId = games;

            if (!userGameRepo.CheckDuplicateUserGame(model.UserId, model.GameId))
            {
                userGameRepo.Create(model);
            }

            return RedirectToAction("Details", "User", new { id = model.UserId });

        }

        public ActionResult Delete(int id)
        {
            var userGame = userGameRepo.GetById(id);
            int userId = userGame.UserId;
            userGameRepo.Delete(userGame);
            return RedirectToAction("Details", "User", new { id = userId });
        }
    }
}
