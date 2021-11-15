using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;
using Vezeeta.ViewModel;

namespace Vezeeta.Controllers
{
    public class AppointmentFormViewModelsController : Controller
    {
        private VezeetaIdentity db = new VezeetaIdentity();

        // GET: AppointmentFormViewModels
        public ActionResult Index()
        {
            return View(db.AppointmentFormViewModels.ToList());
        }

        // GET: AppointmentFormViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentFormViewModel appointmentFormViewModel = db.AppointmentFormViewModels.Find(id);
            if (appointmentFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appointmentFormViewModel);
        }

        // GET: AppointmentFormViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentFormViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Time,Detail,Status,Patient,Doctor,Heading")] AppointmentFormViewModel appointmentFormViewModel)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentFormViewModels.Add(appointmentFormViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointmentFormViewModel);
        }

        // GET: AppointmentFormViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentFormViewModel appointmentFormViewModel = db.AppointmentFormViewModels.Find(id);
            if (appointmentFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appointmentFormViewModel);
        }

        // POST: AppointmentFormViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Time,Detail,Status,Patient,Doctor,Heading")] AppointmentFormViewModel appointmentFormViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentFormViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointmentFormViewModel);
        }

        // GET: AppointmentFormViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentFormViewModel appointmentFormViewModel = db.AppointmentFormViewModels.Find(id);
            if (appointmentFormViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appointmentFormViewModel);
        }

        // POST: AppointmentFormViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentFormViewModel appointmentFormViewModel = db.AppointmentFormViewModels.Find(id);
            db.AppointmentFormViewModels.Remove(appointmentFormViewModel);
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
