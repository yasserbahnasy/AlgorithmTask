using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgorithmTaskYasserBahnasy.Models;

namespace AlgorithmTaskYasserBahnasy.Controllers
{
    [Authorize]
    

    public class DepartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departs
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Index()
        {
            var departs = db.Departs.Include(d => d.user);
            return View(departs.ToList());
        }

        // GET: Departs/Details/5
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // GET: Departs/Create
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Users.Where(a=>a.UserType == "User" ), "Id", "FullName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Create(Depart depart)
        {
            var dep = db.Departs.Where(a=>a.DepName == depart.DepName).Count();
            
            db.Departs.Add(depart);
            db.SaveChanges();
                
            ViewBag.ManagerId = new SelectList(db.Users.Where(a => a.UserType == "User"), "Id", "FullName");
            return View("Create", new Depart());
        }

        // GET: Departs/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.Users, "Id", "UserType", depart.ManagerId);
            return View(depart);
        }

        // POST: Departs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Edit([Bind(Include = "id,DepName,ManagerId")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Users, "Id", "UserType", depart.ManagerId);
            return View(depart);
        }


        // GET: Departs/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // POST: Departs/Delete/5
        [Authorize(Roles = "Admins,SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Depart depart = db.Departs.Find(id);
            db.Departs.Remove(depart);
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
