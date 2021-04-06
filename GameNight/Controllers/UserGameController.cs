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
    }
}
