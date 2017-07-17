using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaseballApp.Models
{
    public class ApplyForTeam
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string UserName { get; set; }
        [Display(Name = "Team you wish to apply for")]
        public string TeamName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }

        public bool VerifyUser(ApplicationUser user)
        {
            if (context.Users.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}