using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vezeeta.Controllers
{
    public class DoctorProfileController : Controller
    {
        // GET: DoctorProfile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoctorProfile()
        {
            return View();

        }
    }
}