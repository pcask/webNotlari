using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ana Sayfa
        public ActionResult homePage()
        {
            return View();
        }

        // Hakkımızda
        public ActionResult about()
        {
            return View();
        }

        // İletişim
        public ActionResult contact()
        {
            return View();
        }

        public ActionResult References()
        {
            return View();
        }
    }
}