using System.Web;
using System.Web.Optimization;
using TrungTamTinHoc.App_Start.Bundle;

namespace TrungTamTinHoc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles = LayoutAdminBundle.RegisterBundles(bundles);
            bundles = LayoutUserBundle.RegisterBundles(bundles);
            bundles = AdminBundle.RegisterBundles(bundles);
            bundles = HomeBundle.RegisterBundles(bundles);
            //BundleTable.EnableOptimizations = true;
        }
    }
}
