using GameNight.Models;
using GameNight.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Controllers
{
    public class UserController : Controller
    {

        IRepository<User> userRepo;

        public UserController(IRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public ViewResult Index()
        {
            var userList = userRepo.GetAll();
            return View(userList);
        }

        public ViewResult Details(int id)
        {
            var user = userRepo.GetById(id);
            return View(user);
        }

        public ViewResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            userRepo.Create(model);
            return RedirectToAction("Details", new { id = model.Id});
        }

        public ViewResult Update(int id)
        {
            var user = userRepo.GetById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User model)
        {
            var user = userRepo.GetById(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            if (String.IsNullOrEmpty(model.ProfilePic))
            {
                user.ProfilePic = "/images/gamepiece_icon.png";
            }
            else
            {
                user.ProfilePic = model.ProfilePic;
            }
            user.Location = model.Location;
            user.Bio = model.Bio;
            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = model.Password;
            }
            userRepo.Update(user);
            return RedirectToAction("Details", new { id = model.Id });

        }

        public ActionResult Delete(int id)
        {
            var user = userRepo.GetById(id);
            userRepo.Delete(user);
            return RedirectToAction("Index");
        }

        public ViewResult Leaderboard()
        {
            var userList = userRepo.GetAll();
            userList.OrderBy(x => x.WinPercent).ToList();
            return View(userList);
        }
    }
}
