using EF_CodeFirst.Models;
using EF_CodeFirst.Models.Manager;
using EF_CodeFirst.ViewModels.Home;
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

            KisilerVeAdresler model = new KisilerVeAdresler
            {
                Adresler = db.Adresler.ToList(),
                Kisiler = db.Kisiler.ToList()
            };

            return View(model);
        }
    }
}