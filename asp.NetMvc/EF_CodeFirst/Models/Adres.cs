using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models
{
    public class Adres
    {
        public int AdresId { get; set; }
        public string AdresTanım { get; set; }

        public int Kisi_Id { get; set; }
        public Kisi Kisi { get; set; }
    }
}