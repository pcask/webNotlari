using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EF_CodeFirst.Models
{
    public class Adres
    {
        public int AdresId { get; set; }
        public string AdresTanim { get; set; }
        public int Kisi_Id { get; set; }

        [ScriptIgnore]
        public Kisi Kisi { get; set; }
    }
}