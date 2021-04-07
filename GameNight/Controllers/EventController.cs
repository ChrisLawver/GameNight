using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        public ViewResult Create()
        {
            ViewBag.Games = eventRepo.GetAllGames();
            return View(new Event() { PlayedOn  = DateTime.Now });
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

        public ActionResult Delete(int id)
        {
            var event1 = eventRepo.GetById(id);
            eventRepo.Delete(event1);
            return RedirectToAction("Index");
        }
    }
}
