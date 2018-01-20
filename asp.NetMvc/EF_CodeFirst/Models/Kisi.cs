using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<Adres> Adresler { get; set; }
    }
}