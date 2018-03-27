using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EF_CodeFirst.Models
{
    public class Kisi
    {
        public Kisi()
        {
            Adresler = new List<Adres>();
        }

        public int KisiId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        [ScriptIgnore] // Data Json formatına dönüştürülürken Serialization ( serileştirme ) işlemine tabi tutulmaması için kullanılır.
        public List<Adres> Adresler { get; set; }
    }
}