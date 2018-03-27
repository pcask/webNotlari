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

        [HttpPost]
        public JsonResult kisiSilModal(int kisiID)
        {
            DatabaseContext db = new DatabaseContext();
            Kisi kisi = db.Kisiler.Where(k => k.KisiId == kisiID).FirstOrDefault();

            bool kisiVarMi = kisi != null;

            return Json(new { Result = kisi, HasPerson = kisiVarMi });
        }


        [HttpPost]
        public ActionResult kisiSil(int kisiID)
        {
            DatabaseContext db = new DatabaseContext();
            Kisi kisi = db.Kisiler.Where(k => k.KisiId == kisiID).FirstOrDefault();
            

            if (kisi == null)
                return null;

            db.Kisiler.Remove(kisi);
            int sonuc = db.SaveChanges();

            if (sonuc < 1)
                return null;

            List<Kisi> kisiler = db.Kisiler.ToList();

            return PartialView("_PartialKisilerTablosu", kisiler);

        }

        [HttpPost]
        public JsonResult adresSilModal(int adresID)
        {
            DatabaseContext db = new DatabaseContext();

            Adres silinecekAdres = db.Adresler.Where(a => a.AdresId == adresID).FirstOrDefault();
            Kisi aitOlduguKisi = db.Kisiler.Where(p => p.KisiId == silinecekAdres.Kisi_Id).FirstOrDefault();

            bool adresVarmi = silinecekAdres != null;

            return Json(new { Address = silinecekAdres, Person = aitOlduguKisi, HasAddress = adresVarmi }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult adresSil(int adresID)
        {
            DatabaseContext db = new DatabaseContext();

            Adres silinecekAdres = db.Adresler.Where(a => a.AdresId == adresID).FirstOrDefault();

            if (silinecekAdres == null)
                return null;

            db.Adresler.Remove(silinecekAdres);
            int sonuc = db.SaveChanges();

            if (sonuc < 1)
                return null;

            List<Adres> adresler = db.Adresler.Include("Kisi").ToList();

            return PartialView("_PartialAdreslerTablosu", adresler);
        }
    }
}