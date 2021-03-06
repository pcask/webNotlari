﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcGiris.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet] // Default olarak methodlarda Get işlemleri yapılır
        public ActionResult Index()
        {
            // Views Klasörünün içindeki Home Klasöründe bulunan Index.cshtml i döner.
            return View();
        }

        [HttpPost] // Post işlemleri yapılacağı zaman Bu attribute method'a uygulanır.
        public ActionResult PostIslemiYapilacak()
        {
            return View();
        }

        public ActionResult RazorViewEngine()
        {
            return View();
        }

        public ActionResult HtmlHelpers()
        {
            return View();
        }

        public ActionResult UrlHelper()
        {
            return View();
        }

        public ActionResult HttpUtility()
        {
            return View();
        }
    }
}