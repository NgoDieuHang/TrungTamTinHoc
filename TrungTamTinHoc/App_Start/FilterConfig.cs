using System.Web;
using System.Web.Mvc;
using TTTH.Common.Filters;

namespace TrungTamTinHoc
{
    public class FilterConfig : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AdminLogin());
            filters.Add(new Authentication());
        }
    }
}
