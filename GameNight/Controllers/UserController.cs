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
            userRepo.Update(model);
            return RedirectToAction("Details", new { id = model.Id });

        }

        public ActionResult Delete(int id)
        {
            var user = userRepo.GetById(id);
            userRepo.Delete(user);
            return RedirectToAction("User");
        }
    }
}
