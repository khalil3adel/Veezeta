using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;

namespace Vezeeta.Controllers
{
    public class SetupVeezeteBookController : Controller
    {

        VezeetaIdentity db = new VezeetaIdentity();


        // GET: SetupVeezeteBook
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult setupVeezete()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult setupVeezete([Bind(Include = "ExamineFee ,Area,City,AddressDetails")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                    db.Doctors.Add(doctor);
                    db.SaveChanges();
                    return RedirectToAction("createentity", "CreateEntity");

            }

            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", doctor.AdminID);
            return View(doctor);
        }



    }
}