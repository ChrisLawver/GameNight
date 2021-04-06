using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Controllers
{
    public class GameController : Controller
    {

        IRepository<Game> gameRepo;

        public GameController(IRepository<Game> gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public ViewResult Index()
        {
            var gameList = gameRepo.GetAll();
            return View(gameList);
        }

        public ViewResult Details(int id)
        {
            var game = gameRepo.GetById(id);
            return View(game);
        }

        public ViewResult Create()
        {
            return View(new Game());
        }

        [HttpPost]
        public ActionResult Create(Game model)
        {
            gameRepo.Create(model);
            return View(model);
        }

        public ViewResult Update(int id)
        {
            var game = gameRepo.GetById(id);
            return View(game);
        }

        [HttpPost]
        public ActionResult Update(Game model)
        {
            gameRepo.Update(model);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var game = gameRepo.GetById(id);
            gameRepo.Delete(game);
            return RedirectToAction("Game");
        }
    }
}
