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
            return View(new Event());
        }

        [HttpPost]
        public ActionResult Create(Event model)
        {
            eventRepo.Create(model);
            return View(model);
        }

        public ViewResult Update(int id)
        {
            var event1 = eventRepo.GetById(id);
            return View(event1);
        }

        [HttpPost]
        public ActionResult Update(Event model)
        {
            eventRepo.Update(model);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var event1 = eventRepo.GetById(id);
            eventRepo.Delete(event1);
            return RedirectToAction("Event");
        }
    }
}
