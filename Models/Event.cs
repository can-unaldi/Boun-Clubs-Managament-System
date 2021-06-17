using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string ClubId { get; set; }
        public string ClubName { get; set; }
        public string EventName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EventDescription { get; set; }
        public int ParticipantCount { get; set; }
        public bool Revenue { get; set; }
        public bool Media { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public string Speaker { get; set; }
        public int AdvisorApproval { get; set; }
        public int ReservationApproval { get; set; }
        public int KakApproval { get; set; }
        public int DeanAproval { get; set; }

    }
}
