using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.Models
{
    public class MailAddress
    {
        public string country { get; set; }
        public string sity { get; set; }
        public string street { get; set; }

        public int homenum { get; set; }
        public int index { get; set; }

        public string Date { get; set; }

        public MailAddress(string Country, string Sity, string Street, int Homenum, int Index, string date)
        {
            country = Country;
            sity = Sity;
            street = Street;
            homenum = Homenum;
            index = Index;
            Date = date;
        }
    }
}