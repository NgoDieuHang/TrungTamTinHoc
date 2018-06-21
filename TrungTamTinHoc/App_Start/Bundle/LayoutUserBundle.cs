using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TrungTamTinHoc.App_Start.Bundle
{
    public class LayoutUserBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/userCommon").Include(
                "~/public/assets/jquery/dist/jquery.js",
                "~/public/assets/bootstrap/dist/js/bootstrap.js",
                "~/public/js/layout-user/modernizr-2.8.3.js",
                "~/public/js/layout-user/jquery.nivo.slider.js",
                "~/public/js/layout-user/home.js",
                "~/public/js/layout-user/jquery.meanmenu.js",
                "~/public/js/layout-user/wow.js",
                "~/public/js/layout-user/owl.carousel.js",
                "~/public/js/layout-user/jquery.scrollUp.js",
                "~/public/js/layout-user/waypoints.js",
                "~/public/js/layout-user/jquery.counterup.js",
                "~/public/assets/slick/slick/slick.js",
                "~/public/js/layout-user/plugins.js",
                "~/public/js/layout-user/main.js",
                "~/public/js/common/jquery-form.js",
                "~/public/js/common/jquery-cookie.js",
                "~/public/js/common/common.js",
                "~/public/js/common/base64.js",
                "~/public/js/common/message.js",
                "~/public/js/common/jquery.error-style.js",
                "~/public/js/common/jquery-ui.js",
                "~/public/js/common/jquery.alerts.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/userCommon").Include(
                "~/public/assets/bootstrap/dist/css/bootstrap.css",
                "~/public/assets/bootstrap/dist/css/bootstrap-theme.css",
                "~/public/assets/font-awesome-4.7.0/css/font-awesome.css",
                "~/public/css/layout-user/owl.carousel.css",
                "~/public/css/common/jquery-ui.css",
                "~/public/css/layout-user/meanmenu.css",
                "~/public/css/layout-user/animate.css",
                "~/public/css/layout-user/nivo-slider.css",
                "~/public/css/layout-user/preview.css",
                "~/public/assets/montserrat/css/material-design-iconic-font.css",
                "~/public/assets/slick/slick/slick.css",
                "~/public/assets/montserrat/css/style.css",
                "~/public/css/layout-user/responsive.css",
                "~/public/css/common/error-notify.css"
            ));
            return bundles;
        }
    }
}