using BounClubs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public interface IEventRepository
    {
        Event GetById(int eventId);
        IQueryable<Event> Events { get; }
        void CreateEvent(Event clubEvent);
        void UpdateEvent(Event clubEvent);
        void DeleteEvent(int eventId);
        void AdvisorApprove(int eventId);
        void AdvisorDeny(int eventId);
        void ReservationApprove(int eventId);
        void ReservationDeny(int eventId);
        void KakApprove(int eventId);
        void KakDeny(int eventId);
        void DeanApprove(int eventId);
        void DeanDeny(int eventId);

    }
}
