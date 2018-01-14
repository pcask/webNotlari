using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFirst.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public string AdresTanım { get; set; }
        public Kisi Kisi { get; set; }
    }
}