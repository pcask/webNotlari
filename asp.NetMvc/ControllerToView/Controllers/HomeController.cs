using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homePage()
        {
            //**********************   ViewData   ************************//

            // ViewData ViewDataDictionary tipinden ControllerBase sınıfının bir propertisidir. Dictionary ( sözlük ) tipinden bir properti olduğundan anahtar key ikilisi barındırır.

            //         Key          Value 
            ViewData["text1"] = "Sezer";
            ViewData["check1"] = true;

            // Aynı key değerine sahip bir Dictionary olmayacağı için Dictionary içerisinde var olan bir Key'e set işlemi yapılırsa o Key'e ait önceki değer gidecek ve son atanan değer ele anılacaktır.
            ViewData["text1"] = "Sezer Ayran";

            ViewData["sayi1"] = 20;
            ViewData["sayi2"] = 18;


            //**********************   ViewBag   ***********************//

            // ViewBag dynamic tipinden ControllerBase sınıfının bir propertisidir. Dynamic tipinden olduğu için nesnenin tipi çalışma zamnında belirlenir. ViewData'nın sytax'ı ile uğraşmak yerine ViewBag nesnesi çıkarılmıştır denilebilir. ViewBag de arka planda ViewData olarak ele alınacaktır.

            ViewBag.text2 = "Sezer Ayran";
            ViewBag.check2 = true;

            ViewBag.sayi3 = 20;
            ViewBag.sayi4 = 18;

            //**********************   TempData   ***********************//

            // TempData TempDataDictionary tipinden ControllerBase sınıfının bir propertisidir.  Dictionary ( sözlük ) tipinden bir properti olduğundan anahtar key ikilisi barındırır.
            
            // ** ViewData ile benzer kullanımı olması yanı sıra, ViewData ve ViewBag nesnelerinin değerlerine sadece oluşturulduğu Action'dan ulaşılabilirken TempData nesnesine oluşturulduğu Actiondan ve ardından çağrılan başka bir Action'dan da TempData nesnesine erişilebilir. Fakat sadece oluşturulduğu Action'dan sonra çağrılan ilk Action'dan erişilebilir, Daha sonraki Action çağrılarından erişilemez.

            TempData["text1"] = "Sezer Ayran";
            TempData["check1"] = true;

            TempData["sayi1"] = 20;
            TempData["sayi2"] = 18;

            return View();
        }

        [HttpPost]
        public ActionResult homePage(string userName)
        {
            TempData["username"] = userName;
            return RedirectToAction("tempDataDeneme");
        }

        public ActionResult tempDataDeneme()
        {
            return View();
        }
    }
}