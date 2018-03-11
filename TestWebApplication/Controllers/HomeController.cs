using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using TestWebApplication.Models;
using TestWebApplication.HelperClasses;

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
            ServerSelection selection = GetAllServers();
            return View(selection);
        }
        [HttpPost]
        public ActionResult Helper(ServerSelection obj)
        {
            GlobalVariables.SqlServer = obj.SelectedValue;
            //Получение всех sql server
            ServerSelection selection = GetAllServers();
            return View(selection);
        }
        
        /// <summary>
        /// Возвращает список всех активных серверов на машине.
        /// </summary>
        /// <returns>Список активных серверов на машине</returns>
        private ServerSelection GetAllServers()
        {
            ServerSelection selection = new ServerSelection();
            List<SelectListItem> ddlInstances = new List<SelectListItem>();
            if (GlobalVariables.DdlInstances == null)
            {
                DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach (DataRow dr in dt.Rows)
                {
                    string value = string.Concat(dr["ServerName"], "\\", dr["InstanceName"]);
                    ddlInstances.Add(new SelectListItem() { Text = value, Value = value });
                }
                GlobalVariables.DdlInstances = ddlInstances;
            }
            else
                ddlInstances = GlobalVariables.DdlInstances;

            selection.ListValue = new SelectList(ddlInstances, "Text", "Value");
            ViewBag.Servers = ddlInstances;
            return selection;
        }

        /// <summary>
        /// Получает список всех почтовых адресов из базы PostDB.
        /// </summary>
        /// <returns>Список почтовых адресов</returns>
        public JsonResult GetPeople()
        {
            string sqlServer = GlobalVariables.SqlServer;
            if (string.IsNullOrEmpty(sqlServer)) return null;

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
            JsonResult testResult = Json(postData, JsonRequestBehavior.AllowGet);
            return testResult;
        }

    }
}
