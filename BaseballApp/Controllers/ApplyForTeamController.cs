using BaseballApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BaseballApp.Controllers
{
    public class ApplyForTeamController : Controller
    {
        private BaseballProjectEntities1 db = new BaseballProjectEntities1();
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: ApplyForTeam
        public ActionResult Index()
        {
            var TeamsSelectListItems = new SelectList(db.Teams,"TeamName","TeamName");
            ViewBag.TeamsSelectListItems = TeamsSelectListItems;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ApplyForTeam application, string userName)
        {
            var TeamsSelectListItems = new SelectList(db.Teams, "TeamName", "TeamName");
            ViewBag.TeamsSelectListItems = TeamsSelectListItems;
            var user = (ApplicationUser)context.Users.Where(u => u.UserName == userName).SingleOrDefault();
            
            
            
                string message = application.FirstName + " " + application.LastName + " "
                    + "would like to join the " + application.TeamName + ". " + "You can " +
                    "reach them at " + application.Email + " or call at " + application.PhoneNumber + ". "
                    + "The username to change the role on is " + application.UserName + ". " +
                    "Here is what they have to say. " + application.Notes;

                SendEmail("bblldave@gmail.com", message);
            
            return View();
        }

        public static bool SendEmail (string SentTo, string Text)
        {
            MailMessage message = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            message.From = new MailAddress("bblldave@gmail.com");
            message.To.Add(SentTo);
            message.Subject = "Player Application";
            message.Body = Text;
            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("bblldave", "gabby1234");
            SmtpServer.EnableSsl = true;

          

            try
            {
                SmtpServer.Send(message);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}