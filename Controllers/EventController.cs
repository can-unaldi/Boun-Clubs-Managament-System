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
    public class EventController : Controller
    {
        private IEventRepository repository;
        private IClubRepository clubRepository;
        private UserManager<ApplicationUser> userManager;
        public EventController(IEventRepository repo, IClubRepository _clubRepository, UserManager<ApplicationUser> _userManager)
        {
            repository = repo;
            clubRepository = _clubRepository;
            userManager = _userManager;
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event clubEvent)
        {
            repository.CreateEvent(clubEvent);
            return RedirectToAction("Manage", "Club");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var clubEvent = repository.GetById(id);
            foreach (var club in clubRepository.Clubs)
            {
                if (club.ClubUserName==clubEvent.ClubId)
                {
                    @ViewData["clubmail"] = club.ClubMail;
                    @ViewData["clubimg"] = club.ClubLogo;
                    @ViewData["clubweb"] = club.ClubWebSite;
                }
            }
            return View(clubEvent);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(repository.GetById(id));
        }
        [HttpPost]
        public IActionResult Update(Event clubEvent)
        {
            repository.UpdateEvent(clubEvent);
            return RedirectToAction("Manage", "Club");
        }
        public IActionResult Delete(int id)
        {
            repository.DeleteEvent(id);
            return RedirectToAction("Manage", "Club");
        }
        public IActionResult DeleteAdmin(int id)
        {
            repository.DeleteEvent(id);
            return RedirectToAction("Events", "Admin");
        }
    }
}
