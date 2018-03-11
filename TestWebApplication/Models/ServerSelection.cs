using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWebApplication.Models
{
    public class ServerSelection
    {
        public List<string> ServerList;
        public SelectList ListValue { get; set; }
        public string SelectedValue { get; set; }
    }
}