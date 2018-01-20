using EF_CodeFirst.Models;
using EF_CodeFirst.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homePage()
        {
            DatabaseContext db = new DatabaseContext();

            List<Kisi> kisiler = db.Kisiler.ToList();


            return View(kisiler);
        }
    }
}