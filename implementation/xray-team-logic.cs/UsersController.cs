using BaseballApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BaseballApp.Controllers
{

    [Authorize]
    public class UsersController : Controller
    {
        public enum SignInRole { Admin, User, Player, Coach, NotAuthorized};
        ApplicationDbContext context;
        public UsersController()
        {
            context = new ApplicationDbContext();
        }

        //Get the user type when logging in
        public SignInRole GetUserType()
        {
            if(User.Identity.IsAuthenticated)
            {
                
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return SignInRole.Admin;
                }
                else if(s[0].ToString() == "Coach")
                {
                    return SignInRole.Coach;
                }
                else if (s[0].ToString() == "Player")
                {
                    return SignInRole.Player;
                }
                else
                {
                    return SignInRole.User;
                }
            }
            else
            {
                return SignInRole.NotAuthorized;
            }
        }
        // GET: Users 
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool isCoachUser()
        {
            if(User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Coach")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                //ViewBag.displayMenu = "No";

                if (GetUserType() == SignInRole.Admin)
                {
                    ViewBag.displayMenu = "Admin";
                    return View();
                }
                else if (GetUserType() == SignInRole.Coach)
                {
                    ViewBag.displayMenu = "Coach";
                    return View();
                }
                else if (GetUserType() == SignInRole.Player)
                {
                    ViewBag.displayMenu = "Player";
                    return View();
                }
                else if (GetUserType() == SignInRole.User)
                {
                    ViewBag.displayMenu = "User";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }

        public ActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = context.Users.Find(Id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.RolesSelectListItems = new SelectList(context.Roles,"Id","Name");
           
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            
            if (ModelState.IsValid)
            {
               
            }

            

            return View(user);
        }


    }
}