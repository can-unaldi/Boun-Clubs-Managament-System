using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class EventCreateModel
    {
        [Required]
        public string ClubId { get; set; }
        [Required]
        public string ClubName { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public int ParticipantCount { get; set; }
        [Required]
        public bool Revenue { get; set; }
        [Required]
        public bool Media { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Place { get; set; }

        public string Speaker { get; set; }

        public int AdvisorApproval { get; set; }
        public int ReservationApproval { get; set; }
        public int KakApproval { get; set; }
        public int DeanAproval { get; set; }
    }
}
