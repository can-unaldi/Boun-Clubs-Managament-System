using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BounClubs.Models
{
    public class ClubCreateModel
    {
        [Required]
        public string ClubUserName { get; set; }
        [Required]
        public string ClubName { get; set; }
        [Required]
        public string ClubDescription { get; set; }
        [Required]
        public string ClubMail { get; set; }
        [Required]
        public string ClubWebSite { get; set; }
        [Required]
        public string ClubAdvisorUserName { get; set; }
        [Required]
        public string ClubLogo { get; set; }
    }
}
