using BounClubs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class EfEventRepository : IEventRepository
    {
        private ApplicationOtherDbContext context;
        private UserManager<ApplicationUser> userManager;
        public EfEventRepository(ApplicationOtherDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }

        public IQueryable<Event> Events => context.Events;

        public void AdvisorApprove(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.AdvisorApproval = 1;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void AdvisorDeny(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.AdvisorApproval = 2;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void CreateEvent(Event clubEvent)
        {
            clubEvent.AdvisorApproval = 0;
            clubEvent.DeanAproval = 0;
            clubEvent.KakApproval = 0;
            clubEvent.ReservationApproval = 0;
            context.Events.Add(clubEvent);
            context.SaveChanges();
        }

        public void DeanApprove(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.DeanAproval = 1;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void DeanDeny(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.DeanAproval = 2;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void DeleteEvent(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                context.Events.Remove(clubEvent);
                context.SaveChanges();
            }
        }

        public Event GetById(int eventId)
        {
            return context.Events.FirstOrDefault(i => i.EventId == eventId);
        }

        public void KakApprove(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.KakApproval = 1;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void KakDeny(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.KakApproval = 2;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void ReservationApprove(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.ReservationApproval = 1;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void ReservationDeny(int eventId)
        {
            var clubEvent = GetById(eventId);
            if (clubEvent != null)
            {
                clubEvent.ReservationApproval = 2;
                context.Events.Update(clubEvent);
                context.SaveChanges();
            }
        }

        public void UpdateEvent(Event clubEvent)
        {
            context.Events.Update(clubEvent);
            context.SaveChanges();
        }
    }
}
