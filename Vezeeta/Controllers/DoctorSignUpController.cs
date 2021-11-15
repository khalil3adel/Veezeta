using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;

namespace Vezeeta.Controllers
{
    public class DoctorSignUpController : Controller
    {

        VezeetaIdentity db = new VezeetaIdentity();


        // GET: DoctorSignUp
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult doctorSignup()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult doctorSignup([Bind(Include = "FName,LName,PassWord,Image,Specilty,Phone,Email")] Doctor doctor, HttpPostedFileBase DocImg)
        {
            if (ModelState.IsValid)
            {
                if (db.Doctors.Any(p => p.Email == doctor.Email))
                {
                    ModelState.AddModelError("", "Doctor already exists.");
                }
                else
                {
                 //  ViewBag.Specilty = new SelectList(db.Doctors, "DoctorID", "Specilty", doctor.Specilty);
                    db.Doctors.Add(doctor);
                    db.SaveChanges();

                    String DocFileName = doctor.DoctorID.ToString() + "." + DocImg.FileName.Split('.')[1];
                    DocImg.SaveAs(Server.MapPath("~/images/") + DocFileName);
                    doctor.Image = DocFileName;
                    db.SaveChanges();

                    return RedirectToAction("createentity", "CreateEntity");
                }
                
            }

            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", doctor.AdminID);
            return View(doctor);
        }


    }
}