using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{

    // TODO Er kun lige blevet autooprettet. Gælder også Views. 

    public class AdminRegistrationsController : Controller
    {
        
        private glsoverviewdbEntities db = new glsoverviewdbEntities();

        // GET: AdminRegistrations
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.car).Include(r => r.employee);
            return View(registrations.ToList());
        }

        // GET: AdminRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: AdminRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.cars, "Id", "Licenseplate");
            ViewBag.EmployeeId = new SelectList(db.employees, "Id", "EmpNo");
            return View();
        }

        // POST: AdminRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Comment,CommentHandled,CarId,EmployeeId")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.cars, "Id", "Licenseplate", registration.CarId);
            ViewBag.EmployeeId = new SelectList(db.employees, "Id", "EmpNo", registration.EmployeeId);
            return View(registration);
        }

        // GET: AdminRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.cars, "Id", "Licenseplate", registration.CarId);
            ViewBag.EmployeeId = new SelectList(db.employees, "Id", "EmpNo", registration.EmployeeId);
            return View(registration);
        }

        // POST: AdminRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Comment,CommentHandled,CarId,EmployeeId")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.cars, "Id", "Licenseplate", registration.CarId);
            ViewBag.EmployeeId = new SelectList(db.employees, "Id", "EmpNo", registration.EmployeeId);
            return View(registration);
        }

        // GET: AdminRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: AdminRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration registration = db.registrations.Find(id);
            db.registrations.Remove(registration);
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
