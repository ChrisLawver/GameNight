using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Result = "You have successfully created a game!";
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
            ViewBag.Result = "You have successfully updated a game!";
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var game = gameRepo.GetById(id);
            gameRepo.Delete(game);
            return RedirectToAction("Index");
        }

        public ActionResult CheckGame(string externalId, string name, string image, int minPlayers, int maxPlayers, string description)
        {
            var game = gameRepo.GetByExternalId(externalId); //add method to repo!
            //check to see if game exists
            if(game == null)
            {
                game = new Game();
                game.ExternalId = externalId;
                game.Title = name;
                game.Image = image;
                game.MinPlayers = minPlayers;
                game.MaxPlayers = maxPlayers;
                game.Description = description;
                //add game
                gameRepo.Create(game);
            }
            
            return RedirectToAction("Details", new { id = game.Id});
            
        }
    }
}
