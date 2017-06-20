using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseballApp.Models;

namespace BaseballApp.Controllers
{
    public class statsController : Controller
    {
        private BaseballProjectEntities db = new BaseballProjectEntities();

        // GET: stats
        public ActionResult Index()
        {
            var stats = db.stats.Include(s => s.Player);
            return View(stats.ToList());
        }

        // GET: stats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // GET: stats/Create
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Players, "playerID", "LastName");
            return View();
        }

        // POST: stats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,G,AB,R,H,SecondBase,ThirdBase,HR,RBI,BB,K,SB,CS,AVG,SLG,OBP,OPS")] stat stat)
        {
            if (ModelState.IsValid)
            {
                db.stats.Add(stat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Players, "playerID", "LastName", stat.PlayerID);
            return View(stat);
        }

        // GET: stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Players, "playerID", "LastName", stat.PlayerID);
            return View(stat);
        }

        // POST: stats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,G,AB,R,H,SecondBase,ThirdBase,HR,RBI,BB,K,SB,CS,AVG,SLG,OBP,OPS")] stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Players, "playerID", "LastName", stat.PlayerID);
            return View(stat);
        }

        // GET: stats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stat stat = db.stats.Find(id);
            db.stats.Remove(stat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
