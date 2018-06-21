using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TrungTamTinHoc.App_Start.Bundle
{
    public class LayoutAdminBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/adminCommon").Include(
                "~/public/assets/jquery/dist/jquery.js",
                "~/public/assets/bootstrap/dist/js/bootstrap.js",
                "~/public/assets/nprogress/nprogress.js",
                "~/public/assets/fastclick/lib/fastclick.js",
                "~/public/js/common/jquery-form.js",
                "~/public/js/common/jquery-cookie.js",
                "~/public/js/common/common.js",
                "~/public/js/common/message.js",
                "~/public/js/common/jquery.error-style.js",
                "~/public/js/common/jquery.alerts.js",
                "~/public/js/common/admin.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/adminCommon").Include(
                "~/public/assets/bootstrap/dist/css/bootstrap.css",
                "~/public/assets/bootstrap/dist/css/bootstrap-theme.css",
                "~/public/assets/font-awesome-4.7.0/css/font-awesome.css",
                "~/public/assets/nprogress/nprogress.css",
                "~/public/css/common/error-notify.css",
                "~/public/css/common/admin.css"
            ));
            return bundles;
        }
    }
}