using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlgorithmTaskYasserBahnasy.Models;
using System.IO;

namespace AlgorithmTaskYasserBahnasy.Controllers
{
    
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.OrderByDescending(a => a.HiringDate).ToList());
        }

        // GET: Employees/Details/5
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Create()
        {
            var Departments = db.Departs.Where(a => a.Employees.Count < 25);
            ViewBag.DepartmentId = new SelectList(Departments, "id", "DepName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Create(Employee employee,HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), UploadImage.FileName);
                UploadImage.SaveAs(path);
                employee.EmployeeImage = UploadImage.FileName;

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var Departments = db.Departs.Where(a => a.Employees.Count < 25);
            ViewBag.DepartmentId = new SelectList(Departments, "id", "DepName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departs, "id", "DepName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins,SuperAdmin")]
        public ActionResult Edit(Employee employee, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/uploads"), employee.EmployeeImage);
                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    employee.EmployeeImage = upload.FileName;
                }
                

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departs, "id", "DepName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int? EmployeeID)
        {
            
            Employee employee = db.Employees.Find(EmployeeID);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeleteConfirmed(int EmployeeID)
        {
            Employee employee = db.Employees.Find(EmployeeID);
            db.Employees.Remove(employee);
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
