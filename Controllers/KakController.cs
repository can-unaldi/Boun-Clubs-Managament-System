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
    
    public class KakController : Controller
    {
        private IEventRepository repository;
        private IClubRepository clubRepo;
        private UserManager<ApplicationUser> userManager;
        public KakController(IEventRepository _repository, IClubRepository _clubRepo, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            clubRepo = _clubRepo;
            userManager = _userManager;
        }
        [Authorize(Roles = "kakyk, club")]
        public IActionResult Index()
        {

            List<Event> EventsList = new List<Event>();
            foreach (var clubEvent in repository.Events)
            {
                if (clubEvent.AdvisorApproval == 1 && clubEvent.ReservationApproval == 1 && clubEvent.KakApproval==0)
                {
                    @ViewData["eventname"] = clubEvent.EventName;
                    foreach (var club in clubRepo.Clubs)
                    {
                        if (clubEvent.ClubId==club.ClubUserName)
                        {
                            @ViewData["clubmail"] = club.ClubMail;
                            @ViewData["kakmail"] = "kakyk@gmail.com";
                        }
                    }
                    EventsList.Add(clubEvent);
                }
            }

            return View(EventsList);
        }
        [Authorize(Roles = "kakyk")]
        public IActionResult KakYk()
        {
            List<Event> EventsList = new List<Event>();
            foreach (var clubEvent in repository.Events)
            {
                if (clubEvent.AdvisorApproval == 1 && clubEvent.ReservationApproval == 1 && clubEvent.KakApproval == 0)
                {
                    EventsList.Add(clubEvent);
                }
            }

            return View(EventsList);
        }
        [Authorize(Roles = "kakyk")]
        public IActionResult Approve(int id)
        {
            repository.KakApprove(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "kakyk")]
        public IActionResult Deny(int id)
        {
            repository.KakDeny(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "kakyk, club")]
        public IActionResult Contact(int id)
        {
            repository.KakDeny(id);
            return RedirectToAction("Index");
        }

    }
}
