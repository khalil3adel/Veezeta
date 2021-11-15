using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vezeeta.Models;

namespace Vezeeta.Controllers
{
    public class LogInDoctorController : Controller
    { // GET: LogInDoctor
        public ActionResult Index()
        {
            return View();
        }


        VezeetaIdentity db = new VezeetaIdentity();

        public ActionResult Logindoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logindoctor(LoginDoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor Doc = db.Doctors.FirstOrDefault(d => d.Email == model.Email && d.PassWord == model.PassWord);
                if (Doc != null)
                {

                    Session.Add("Email", Doc.Email);
                    Session.Add("Passwod", Doc.PassWord);

                    return RedirectToAction("HomePage", "Doctors");
                }
                ModelState.AddModelError("", "Email or Password Not Correct");

            }
            return View(model);

        }



        public ActionResult LogOut()
        {
            Session.Clear();
            return Content("Session Clear");
        }


    }
}