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
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kisi kisi)
        {
            DatabaseContext db = new DatabaseContext();

            db.Kisiler.Add(kisi);

            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                ViewBag.Result = "Kişi Başarılı Bir Şekilde Kaydedilmiştir.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Kişi Ekleme İşlemi Başarısız!!!";
                ViewBag.Status = "danger";
            }

            return View();
        }

        public ActionResult Duzenle(int? kisiID)
        {
            Kisi kisi = null;

            if (kisiID != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(k => k.KisiId == kisiID).FirstOrDefault();
            }

            return View(kisi);
        }

        [HttpPost]
        public ActionResult Duzenle(Kisi model, int? kisiID)
        {
            DatabaseContext db = new DatabaseContext();
            Kisi kisi = db.Kisiler.Where(k => k.KisiId == kisiID).FirstOrDefault();

            if (kisi != null)
            {
                kisi.Ad = model.Ad;
                kisi.Soyad = model.Soyad;
                kisi.Yas = model.Yas;

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

            return View();
        }
    }
}