using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vezeeta.Controllers
{
    public class CenterPageController : Controller
    {
        // GET: CenterPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Center()
        {
            return View();

        }
    }
}