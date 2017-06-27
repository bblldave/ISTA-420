using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseballApp.Models;
using Microsoft.AspNet.Identity;

namespace BaseballApp.Controllers
{
    public class HomeController : Controller
    {
        private BaseballProjectEntities1 db = new BaseballProjectEntities1();

        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Team).Include(s => s.Team3);
            var schedules1 = schedules.ToList();
            var q =from s in schedules1 where DateTime.Parse(s.Date) > DateTime.Now && DateTime.Parse(s.Date) < DateTime.Now.AddDays(7) select s;
            return View(q);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    
    }
}