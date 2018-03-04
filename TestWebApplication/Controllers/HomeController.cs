using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using TestWebApplication.Models;
using System.Data;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var obj = { country: "Россия", city: "Москва", street: "Ленина", homenum: 3, index: 446345, Date: "2000-11-22" };
            TestClass obj = new TestClass() {country = "Россия", sity = "Москва", street= "Ленина", homenum= 3, index= 446345, Date = new DateTime(2017, 11, 23) };
            //TestClass[] obk = new TestClass[] { obj };
            //JsonResult res = GetPeople();
            //ViewBag.rand = res;//Json(obk);
            
            return View();
        }
        
        public class TestClass
        {
            public string country;
            public string sity;
            public string street;

            public int homenum;
            public int index;

            public DateTime Date;

        }
        [HttpPost]
        public List<MailAddress> GetPeople()
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=ТЕРМИНАТОР-Д\SQLEXPRESS2012;Initial Catalog=PostDB;Integrated Security=True";
            //conn.Open();
            List<MailAddress> postData = new List<MailAddress>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(@"Data Source=ТЕРМИНАТОР-Д\SQLEXPRESS2012;Initial Catalog=PostDB;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from MailAddress;";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                ViewBag.RowCount = Json(ds.Tables[0].Rows.Count);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    postData.Add(new MailAddress(dr["country"].ToString(), dr["city"].ToString(), dr["street"].ToString(),
                        int.Parse(dr["homenum"].ToString()), int.Parse(dr["index"].ToString()), dr["Date"].ToString()
                        ));
                }
            }
            return postData;
        }

    }
}