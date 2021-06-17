using BounClubs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Controllers
{
    [Authorize(Roles = "reservationoffice")]
    public class ReservationController : Controller
    {
        private IEventRepository repository;
        public ReservationController(IEventRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            List<Event> reservationEvents = new List<Event>();
            foreach (var clubEvent in repository.Events)
            {
                if (clubEvent.AdvisorApproval==1 && clubEvent.ReservationApproval==0)
                {
                    reservationEvents.Add(clubEvent);
                }
            }

            return View(reservationEvents);
        }
        public IActionResult Approve(int id)
        {
            repository.ReservationApprove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Deny(int id)
        {
            repository.ReservationDeny(id);
            return RedirectToAction("Index");
        }
    }
}
