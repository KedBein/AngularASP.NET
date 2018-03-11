using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApplication.HelperClasses
{
    public static class GlobalVariables
    {
        //Хранит выбранный сервер.
        public static string SqlServer
        {
            get
            {
                return HttpContext.Current.Application["SqlServer"] as string;
            }
            set
            {
                HttpContext.Current.Application["SqlServer"] = value;
            }
        }
        //Кеширует список серверов для ускорения.
        public static List<System.Web.Mvc.SelectListItem> DdlInstances
        {
            get
            {
                return HttpContext.Current.Application["DdlInstances"] as List<System.Web.Mvc.SelectListItem>;
            }
            set
            {
                HttpContext.Current.Application["DdlInstances"] = value;
            }
        }
    }


}