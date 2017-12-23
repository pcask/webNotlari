using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcGiris.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Views Klasörünün içindeki Home Klasöründe bulunan Index.cshtml i döner.
            return View();
        }
    }
}