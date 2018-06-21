using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrungTamTinHoc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "Support",
                url: "guide-line",
                defaults: new { controller = "Home", action = "Support", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "TermsConditions",
                url: "terms-conditions",
                defaults: new { controller = "Home", action = "TermsConditions", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "PrivacyPolicy",
                url: "privacy-policy",
                defaults: new { controller = "Home", action = "PrivacyPolicy", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "UserLogin",
                url: "login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "UserRegister",
                url: "dang-ky-tai-khoan",
                defaults: new { controller = "DangKyTaiKhoan", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
