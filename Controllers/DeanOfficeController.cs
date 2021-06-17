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
    [Authorize(Roles = "deanoffice")]
    public class DeanOfficeController : Controller
    {
        private IEventRepository repository;
        private IClubRepository clubRepo;
        private UserManager<ApplicationUser> userManager;
        public DeanOfficeController(IEventRepository _repository, IClubRepository _clubRepo, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            clubRepo = _clubRepo;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            List<Event> EventsList = new List<Event>();
            foreach (var clubEvent in repository.Events)
            {
                if (clubEvent.AdvisorApproval == 1 && clubEvent.ReservationApproval == 1 && clubEvent.KakApproval == 1 && clubEvent.DeanAproval==0)
                {
                    EventsList.Add(clubEvent);
                }
            }

            return View(EventsList);
        }
        public IActionResult Approve(int id)
        {
            repository.DeanApprove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Deny(int id)
        {
            repository.DeanDeny(id);
            return RedirectToAction("Index");
        }
    }
}
