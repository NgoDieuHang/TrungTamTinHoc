using System.Web.Mvc;

namespace TrungTamTinHoc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminLogin",
                "admin/login",
                new { controller = "AdminLogin", action = "Index"}
            );
            context.MapRoute(
                "adminCheckLogin",
                "admin/check-login",
                new { controller = "AdminLogin", action = "CheckLogin"}
            );
            context.MapRoute(
                "adminDashboard",
                "admin/dashboard",
                new { controller = "Dashboard", action = "Index"}
            );
            context.MapRoute(
                "adminDefault",
                "admin/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}