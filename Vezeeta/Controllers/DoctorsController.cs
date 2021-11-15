namespace Vezeeta.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Vezeeta.Models;

 
    public class DoctorsController : Controller
    {
 
        private VezeetaIdentity db = new VezeetaIdentity();

        public ActionResult HomePage()
        {
            var doctor = db.Doctors.Include(a => a.Doctorinsurances).Include(a => a.Area).Include(a => a.City).Include(a => a.Specialty);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "CompanyName");
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.SpeciltyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty");
            return View(doctor.ToList());
        }

        public ActionResult City2()
        {
            var doc = db.Cities.Include(a => a.Areas).ToList();
            List<Area> MasterData = db.Areas.ToList();

            
            
            ViewBag.Ares = new SelectList(db.Areas, "AreaID", "AreaName").ToList();
            return View(doc);
        }

        public ActionResult Details()
        {
            var doctors = db.Doctors.Include(d => d.Admin).Include(a => a.City).Include(a => a.Area).Include(s => s.Specialty);
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "CompanyName");
            ViewBag.AreaID = new SelectList(db.Areas.ToList(), "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.SpeciltyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty");
            return View(doctors.ToList());
        }

      
        public ActionResult search(string docname = null, string sps = null)
        {
            ViewBag.InsuranceID = new SelectList(db.Insurances, "InsuranceID", "CompanyName");
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.SpeciltyID = new SelectList(db.Specialties, "SpecialtyID", "Specilty", sps);
            if (docname != null)
            {
                List<Doctor> doc = db.Doctors
                        .Include(a => a.City)
                        .Include(a => a.Area)
                        .Include(a => a.Specialty)
                        .Where(d => d.FName.ToLower().Contains(docname) || d.LName.ToLower().Contains(docname) || d.Specialty.Specilty.ToLower().Contains(docname) ||d.City.CityName.ToLower().Contains(docname)|| d.Area.AreaName.ToLower().Contains(docname)).ToList();
                return View("Details", doc);
            }
            else
                return View("Details");
        }

       
        public JsonResult GetStateById(int CityID)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return Json(db.Areas.Where(a => a.CityID == CityID), JsonRequestBehavior.AllowGet);
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
