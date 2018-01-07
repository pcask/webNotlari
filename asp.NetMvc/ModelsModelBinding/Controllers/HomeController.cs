using ModelsModelBinding.Models;
using ModelsModelBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homePage()
        {

            Kisi kisi = new Kisi()
            {
                Ad = "Sezer",
                Soyad = "Ayran",
                Yas=25
            };

            return View(kisi);
        }

        [HttpPost]
        public ActionResult homePage(Kisi k)
        {
            return View(k);
        }

        public ActionResult viewlaraOzelModeller()
        {
            Kisi kisi = new Kisi
            {
                Ad = "Sezer",
                Soyad = "Ayran",
                Yas = 25
            };

            Adres adres = new Adres {
                AdresTanimi = "Anonim Cad. Farazi Sok. No: 0",
                Sehir = "İstanbul"
            };

            BirlesikModeller bm = new BirlesikModeller
            {
                AdresNesnesi = adres,
                KisiNesnesi = kisi
            };

            return View(bm);
        }

        [HttpPost]
        public ActionResult viewlaraOzelModeller(BirlesikModeller bm)
        {
            return View(bm);
        }
    }
}