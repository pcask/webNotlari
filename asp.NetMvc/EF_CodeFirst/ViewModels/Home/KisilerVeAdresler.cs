using EF_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.ViewModels.Home
{
    public class KisilerVeAdresler
    {
        public List<Kisi> Kisiler { get; set; }
        public List<Adres> Adresler { get; set; }
    }
}