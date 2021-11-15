using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;
using Vezeeta.Services;
using Vezeeta.ViewModel;

namespace Vezeeta.Controllers
{
    public class RegisterController : Controller
    {
        VezeetaIdentity db = new VezeetaIdentity();

        private readonly UserManager<MyIdentityUser> userManager;
        //private readonly PatientService patientService; 
        public RegisterController()
        {
            var db = new VezeetaIdentity();
            var UserStore = new UserStore<MyIdentityUser>(db);
            userManager = new UserManager<MyIdentityUser>(UserStore);
        }

       
        public ActionResult Register()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "FName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel userinfo )
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "FName");
            if (ModelState.IsValid)
            {
                var identityUser = new MyIdentityUser
                {
                    Email = userinfo.Email,
                    UserName = userinfo.Name,
                };
                if (userinfo.Password == null)
                {
                    return View(userinfo);

                }
                var creationResult = await userManager.CreateAsync(identityUser, userinfo.Password);
                //user Created
                if (creationResult.Succeeded)
                {
                    var userId = identityUser.Id;
                    creationResult = userManager.AddToRole(userId, "Patient");
                }
            }
            return View("RegisterPatient");
        }



        public ActionResult RegisterPatient()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "FName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPatient([Bind(Include = "Name,,Gender,BirthDate,Address,Phone,Email")] Patient patient)
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name");
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "FName");
            if (ModelState.IsValid)
            {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("HomePage", "doctors");
            }

            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Name", patient.AdminID);
            ViewBag.DoctorID = new SelectList(db.Doctors, "DoctorID", "FName", patient.DoctorID);
            return RedirectToAction("HomePage", "doctors");

        }


    }
}