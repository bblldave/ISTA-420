using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaseballApp.Models
{
    public class IdentityModels
    {
    }


    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("data source=davidharris.database.windows.net;initial catalog=BaseballProject;user id=david;password=Pa$$w0rd;multipleactiveresultsets=True;application name=EntityFramework")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}