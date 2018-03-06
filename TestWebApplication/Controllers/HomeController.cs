using System.Collections.Generic;
using System.Web.Mvc;
using TestWebApplication.Models;
using System.Data;
using System.Data.Sql;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Helper()
        {
            //Получение всех sql server
            GetAllServers();
            return View();
        }
        [HttpPost]
        public ActionResult Helper(string obj)
        {
            //Получение всех sql server
            GetAllServers();
            return View();
        }
        //Возможно надо возвращать значение и передавать во View
        private void GetAllServers()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> ddlInstances = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                ddlInstances.Add(string.Concat(dr["ServerName"], "\\", dr["InstanceName"]));
            }
            SelectList servers = new SelectList(ddlInstances);
            ViewBag.Servers = servers;
        }

        public List<MailAddress> GetPeople()
        {
            string sqlServer = string.Empty;

            //Добавить выбор сервера. Скорее всего как-то через веб

            List<MailAddress> postData = new List<MailAddress>();
            DataSet ds = DataAccess.GetAllData(sqlServer);
            
            if (ds != null && ds.Tables.Count > 0)
            {
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