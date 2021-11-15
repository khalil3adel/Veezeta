using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;
using Vezeeta.MyFilters;

namespace Vezeeta.Controllers
{
   //[MyAuthorize]
    public class HomePageController : Controller
    {
        private VezeetaIdentity  db = new VezeetaIdentity();

        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult HomePage()
        //{
        //    return View();

        //}

        //public ActionResult HomePage(string docname/*, string spc, string city, string area*/ )
        //{
        //    List<Doctor> doc = db.Doctors.Where(d => d.FName.Contains(docname)/*&& d.Area.Contains(area)&& d.City.Contains(city)&& d.Specilty==((spc==string.Empty)?d.Specilty : spc)*/).ToList();
        //    ViewBag.area = new SelectList(db.Areas, "ID", "AreaName");
        //    ViewBag.city = new SelectList(db.Cities, "DoctorID", "City");
        //    ViewBag.spec = new SelectList(db.Doctors, "DoctorID", "Specilty");
        //    return View("Index", doc);
        //}
        public ActionResult HomePage()
        {
            //var doctor = db.Doctors.Include(p =>p.).Include(p => p.doctor);

            return View(db.Doctors.ToList());

        }
    }
}