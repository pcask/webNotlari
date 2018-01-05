using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewToController.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet] // Yazılmasada Default değerdir.
        public ActionResult homePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult homePage(string text1, bool check1, string list1)
        {

            // View'dan Controller'a veri parametreler ile gönderilebileceği gibi aşağıdaki gibi bir kullanım ile de veriler alınabilir.
            string txt = Request.Form["text1"];
            string lst = Request.Form["list1"];

            // CheckBox da özeli bir durum söz konusu dönüş değeri olarak her zaman true/false veya tam tersi false/true ikilisini dönüyor. Burda önemli olan kısım CheckBox'ın durumu ilk sırada yer alıyor. Yani CheckBox işaretli ise gelen değer true/false , eğer işaretli değilse false/true
            string chk = Request.Form.GetValues("check1")[0];

            return View();
        }
    }
}