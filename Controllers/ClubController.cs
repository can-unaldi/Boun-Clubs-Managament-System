using BounClubs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Controllers
{
    [Authorize(Roles = "club, admin")]
    public class ClubController : Controller
    {
        private IClubRepository repository;
        private IEventRepository eventRepository;
        private UserManager<ApplicationUser> userManager;

        public ClubController(IClubRepository repo, IEventRepository _eventRepository, UserManager<ApplicationUser> _userManager)
        {
            repository = repo;
            eventRepository= _eventRepository;
            userManager = _userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(repository.Clubs);
        }

        public IActionResult Manage()
        {  
            return View(eventRepository.Events);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Club club)
        {
            repository.CreateClub(club);
            return RedirectToAction("Clubs","Admin");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Update(Club club)
        {
            repository.UpdateClub(club);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete(int id)
        {
            repository.DeleteClub(id);
            return RedirectToAction("Clubs", "Admin");
        }


    }
}
