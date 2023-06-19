using System.Web;
using System.Web.Mvc;

namespace QQQ.Mvc5WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyLoggingFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
