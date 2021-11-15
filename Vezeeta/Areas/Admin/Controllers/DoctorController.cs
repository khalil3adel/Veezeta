using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;

namespace Vezeeta.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private VezeetaIdentity db = new VezeetaIdentity();

        // GET: Admin/Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Admin).Include(d => d.Area).Include(d => d.City).Include(d => d.Specialty).Include(s=>s.DoctorPatients);
            ViewBag.docPatients = new SelectList(db.Patients, "PatientID", "Name");

            return View(doctors.ToList());
        }
        public PartialViewResult searchDoctor(string seachText)
        {
            var Doctor = db.Doctors.Include(p => p.Admin).Include(p => p.DoctorPatients).Include(d => d.Area).Include(d => d.City).Include(d => d.Specialty); 
            var result = Doctor.Where(a => a.FName.ToLower().Contains(seachText) || a.LName.ToLower().Contains(seachText) || a.Phone.ToString().Contains(seachText) || a.Email.ToLower().Contains(seachText)).ToList();
            return PartialView("_GridDoctor", result);
        }

        // GET: Admin/Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Include(p => p.Admin).Include(p => p.DoctorPatients).Include(d => d.Area).Include(d => d.City).Include(d => d.Specialty).FirstOrDefault(a => a.DoctorID == id);
            //Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Admin/Doctors/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.SpecialtyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty");
            return View();
        }

        // POST: Admin/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorID,FName,LName,PassWord,BirthDate,Gender,ExamineFee,Title,Image,SpecialtyID,PromoCode,WaitingTime,Phone,branchName,AreaID,CityID,AddressDetails,Email,Entity,IDImage,TitleImage,AdminID")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", doctor.AdminID);
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", doctor.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", doctor.CityID);
            ViewBag.SpecialtyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty", doctor.SpecialtyID);
            return View(doctor);
        }

        // GET: Admin/Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", doctor.AdminID);
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", doctor.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", doctor.CityID);
            ViewBag.SpecialtyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty", doctor.SpecialtyID);
            return View(doctor);
        }

        // POST: Admin/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorID,FName,LName,PassWord,BirthDate,Gender,ExamineFee,Title,Image,SpecialtyID,PromoCode,WaitingTime,Phone,branchName,AreaID,CityID,AddressDetails,Email,Entity,IDImage,TitleImage,AdminID")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", doctor.AdminID);
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", doctor.AreaID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", doctor.CityID);
            ViewBag.SpecialtyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty", doctor.SpecialtyID);
            return View(doctor);
        }

        // GET: Admin/Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Doctor doctor = db.Doctors.Find(id);
            Doctor doctor = db.Doctors.Include(p => p.Admin).Include(p => p.DoctorPatients).Include(d => d.Area).Include(d => d.City).Include(d => d.Specialty).FirstOrDefault(a => a.DoctorID == id);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Admin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
