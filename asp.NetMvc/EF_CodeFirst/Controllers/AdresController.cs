using EF_CodeFirst.Models;
using EF_CodeFirst.Models.Manager;
using EF_CodeFirst.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();

            //List<SelectListItem> kisiList = new List<SelectListItem>();

            //foreach (var kisi in db.Kisiler.ToList())
            //{
            //    SelectListItem sli = new SelectListItem();

            //    sli.Text = kisi.Ad + " " + kisi.Soyad;
            //    sli.Value = kisi.KisiId.ToString();

            //    kisiList.Add(sli);
            //}


            // Yukarıdaki işlem Linq ile;
            List<SelectListItem> kisiList =
                (from kisi in db.Kisiler.ToList()
                 select new SelectListItem
                 {
                     Text = kisi.Ad + " " + kisi.Soyad,
                     Value = kisi.KisiId.ToString()
                 }).ToList();

            TempData["Kisiler"] = kisiList;
            ViewBag.Kisiler = kisiList;

            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Adres adres)
        {
            DatabaseContext db = new DatabaseContext();

            Kisi seciliKisi = db.Kisiler.Where(k => k.KisiId == adres.Kisi.KisiId).FirstOrDefault();

            if (seciliKisi != null)
            {
                adres.Kisi = seciliKisi;

                db.Adresler.Add(adres);

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Adres Kaydetme İşlemi Başarılı";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Adres Kaydetme İşlemi Başarısız!!!";
                    ViewBag.Status = "danger";
                }
            }

            ViewBag.Kisiler = TempData["Kisiler"];

            return View();
        }

        public ActionResult Duzenle(int? adresID)
        {
            Adres adres = null;

            if (adresID != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(a => a.AdresId == adresID).FirstOrDefault();

                List<SelectListItem> kisiList =
                (from kisi in db.Kisiler.ToList()
                 select new SelectListItem
                 {
                     Text = kisi.Ad + " " + kisi.Soyad,
                     Value = kisi.KisiId.ToString()
                 }).ToList();

                TempData["Kisiler"] = kisiList;
                ViewBag.Kisiler = kisiList;
            }

            return View(adres);
        }


        [HttpPost]
        public ActionResult Duzenle(Adres model, int? adresID)
        {
            DatabaseContext db = new DatabaseContext();

            Adres adres = db.Adresler.Where(a => a.AdresId == adresID).FirstOrDefault();

            if (adres != null)
            {
                Kisi kisi = db.Kisiler.Where(k => k.KisiId == model.Kisi.KisiId).FirstOrDefault();

                adres.AdresTanim = model.AdresTanim;
                adres.Kisi = kisi;

                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.Result = "Güncelleme İşlemi Başarılı.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Güncelleme İşlemi Başarısız!!!";
                    ViewBag.Status = "danger";
                }
            }

            ViewBag.Kisiler = TempData["Kisiler"];

            return View();
        }

    }
}