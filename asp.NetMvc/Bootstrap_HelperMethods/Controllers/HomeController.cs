using Bootstrap_HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap_HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homePage()
        {
            return View();
        }

        public ActionResult homePage2()
        {
            return View();
        }

        public ActionResult homePage3()
        {
            return View();
        }

        public ActionResult bootstrapGenericCustomHelperMethod()
        {
            List<Message> messageList = new List<Message>();

            messageList.Add(new Message { Level = 1, Text = "Bu bir deneme mesajıdır." });
            messageList.Add(new Message { Level = 2, Text = "Bu da bir deneme mesajıdır." });
            messageList.Add(new Message { Level = 3, Text = "Yoksa bu da mı bir deneme mesajıymış." });
            messageList.Add(new Message { Level = 4, Text = "Bu kesin deneme mesajı ya yersen hani." });

            return View(messageList);
        }
    }
}