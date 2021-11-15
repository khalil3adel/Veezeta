using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vezeeta.Controllers
{
    public class HospitalPageController : Controller
    {
        // GET: HospitalPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HospitalPage()
        {
            return View();

        }
    }
}