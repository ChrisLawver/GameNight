﻿using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Controllers
{
    public class UserEventController : Controller
    {

        IRepository<UserEvent> userEventRepo;


        public UserEventController(IRepository<UserEvent> userEventRepo)
        {
            this.userEventRepo = userEventRepo;
        }

        public ViewResult Index()
        {
            return View(userEventRepo.GetAll());
        }

        public ViewResult Create(int eventId)
        {
            var users = userEventRepo.PopulateUserList();

            ViewBag.UserId = users;

            return View(new UserEvent() {EventId = eventId, Id = 0, Active = true});
            
        }

        [HttpPost]
        public ActionResult Create(UserEvent model)
        {
            var users = userEventRepo.PopulateUserList();
            ViewBag.UserId = users;

            model.Event = userEventRepo.GetEventById(model.EventId);

            if (userEventRepo.CheckDuplicateUserEvent(model.UserId, model.EventId))
            {
                ViewBag.Error = "Player is already registered for this event";
                return View(model);
            }
            else if (!userEventRepo.CheckMaxPlayers(model.Event.Game.MaxPlayers, model.Event.Attendees))
            {
                ViewBag.Error = "Cannot exceed maximum player count";
                return View(model);
            }
            else
            {
                userEventRepo.Create(model);
                return RedirectToAction("Details", "Event", new { id = model.EventId });
            }
        }

        public ViewResult CreateByUserId(int eventId, int userId)
        {
            //var users = userEventRepo.PopulateUserList();

            //ViewBag.UserId = users;

            return View(new UserEvent() { EventId = eventId, Id = 0, UserId = userId, Active = true });

        }

        [HttpPost]
        public ActionResult CreateByUserId(UserEvent model)
        {
            //var users = userEventRepo.PopulateUserList();
            //ViewBag.UserId = users;

            model.Event = userEventRepo.GetEventById(model.EventId);

            if (userEventRepo.CheckDuplicateUserEvent(model.UserId, model.EventId))
            {
                ViewBag.Error = "Player is already registered for this event";
                return View(model);
            }
            else if (!userEventRepo.CheckMaxPlayers(model.Event.Game.MaxPlayers, model.Event.Attendees))
            {
                ViewBag.Error = "Cannot exceed maximum player count";
                return View(model);
            }
            else
            {
                userEventRepo.Create(model);
                return RedirectToAction("Details", "Event", new { id = model.EventId });
            }
        }

        public ViewResult Close(int id)
        {
            var userEvent = userEventRepo.GetById(id);

            return View(userEvent);
        }

        [HttpPost]
        public ActionResult Close(UserEvent model)
        {
            model.Active = false;
            userEventRepo.Update(model);

            return RedirectToAction("Close", "Event", new { id = model.EventId });
        }

        public ActionResult Delete(int id)
        {
            var userEvent = userEventRepo.GetById(id);
            int eventId = userEvent.EventId;
            userEventRepo.Delete(userEvent);
            return RedirectToAction("Details", "Event", new { id = eventId });
        }
    }
}

