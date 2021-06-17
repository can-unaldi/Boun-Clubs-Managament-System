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
    [Authorize(Roles = "advisor")]
    public class AdvisorController : Controller
    {
        private IEventRepository repository;
        private IClubRepository clubRepo;
        private UserManager<ApplicationUser> userManager;
        public AdvisorController(IEventRepository _repository, IClubRepository _clubRepo, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            clubRepo = _clubRepo;
            userManager = _userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var userName = user.UserName;
            List<Event> advisorEvents = new List<Event>();
            foreach (var club in clubRepo.Clubs)
            {
                if (club.ClubAdvisorUserName==userName)
                {
                    foreach (var clubEvent in repository.Events)
                    {
                        if (clubEvent.ClubId==club.ClubUserName && clubEvent.AdvisorApproval==0)
                        {
                            advisorEvents.Add(clubEvent);
                        }
                    }
                }
            }
            return View(advisorEvents);
        }
        public IActionResult Approve(int id)
        {
            repository.AdvisorApprove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Deny(int id)
        {
            repository.AdvisorDeny(id);
            return RedirectToAction("Index");
        }
    }
}
