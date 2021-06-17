using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string ClubUserName { get; set; }
        public string ClubName { get; set; }
        public string ClubDescription { get; set; }
        public string ClubMail { get; set; }
        public string ClubWebSite { get; set; }
        public string ClubAdvisorUserName { get; set; }
        public string ClubLogo { get; set; }

    }
}
