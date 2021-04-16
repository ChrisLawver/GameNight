using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Controllers
{
    public class EventController : Controller
    {

        IRepository<Event> eventRepo;

        public EventController(IRepository<Event> eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public ViewResult Index()
        {
            var eventList = eventRepo.GetAll();
            return View(eventList);
        }

        public ViewResult Details(int id)
        {
            var event1 = eventRepo.GetById(id);

            return View(event1);
        }

        public ViewResult Create(int? gameId, int ownerId)
        {
            var games = eventRepo.PopulateGameList();

            string owner = eventRepo.GetUserById(ownerId);

            ViewBag.Games = games;

            if (gameId == null)
            {
                return View(new Event() { OwnerId = ownerId, Owner = owner, PlayedOn = DateTime.Now, Active = true });
            }
            else
            {
                return View(new Event() { GameId = (int) gameId, OwnerId = ownerId, Owner = owner, PlayedOn = DateTime.Now, Active = true });
            }
        }

        [HttpPost]
        public ActionResult Create(Event model)
        {
            ViewBag.Games = eventRepo.GetAllGames();
            eventRepo.Create(model);
            ViewBag.Result = "You have successfully created an Event!";
            return View(model);
        }

        public ViewResult Update(int id)
        {
            ViewBag.Games = eventRepo.GetAllGames();
            var event1 = eventRepo.GetById(id);
            return View(event1);
        }

        [HttpPost]
        public ActionResult Update(Event model)
        {
            ViewBag.Games = eventRepo.GetAllGames();
            eventRepo.Update(model);
            ViewBag.Result = "You have successfully updated an Event!";
            return View(model);
        }

        public ViewResult Close(int id)
        {
            var event1 = eventRepo.GetById(id);
            return View(event1);
        }

        [HttpPost]
        public ActionResult Close(Event model)
        {
            model.Active = false;
            eventRepo.Update(model);
            return RedirectToAction("Details", "Event", new { id = model.Id });
        }

        public ActionResult Delete(int id)
        {
            var event1 = eventRepo.GetById(id);
            eventRepo.Delete(event1);
            return RedirectToAction("Index");
        }
    }
}
