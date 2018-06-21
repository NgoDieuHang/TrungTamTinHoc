using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTinHoc.Areas.Error.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Trả về trang thông báo lỗi 403 - không có quyền truy cập.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <returns>
        /// View lỗi 403
        /// </returns>
        public ActionResult NotAccess()
        {
            return View();
        }
        /// <summary>
        /// Trả về trang thông báo lỗi kèm theo lỗi phát sinh.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <param name="error">
        /// Thông tin lỗi cần hiển thị
        /// </param>
        /// <returns>
        /// View lỗi phát sinh
        /// </returns>
        public ActionResult Error(string error)
        {
            ViewBag.error = error;
            return View();
        }
        /// <summary>
        /// Trả về trang thông báo lỗi 404 - không tìm thấy trang.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <returns>
        /// View lỗi notfound
        /// </returns>
        public ActionResult NotFound()
        {
            return View();
        }
        /// <summary>
        /// Trả về trang thông báo lỗi 500 - lỗi khi xử lý trên server.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <returns>
        /// View lỗi 500
        /// </returns>
        public ActionResult ServerError()
        {
            return View();
        }
        /// <summary>
        /// Trả về thông báo lỗi nếu như chưa login khi xử dụng ajax.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <returns>
        /// Chuỗi Json bao gồm mã lỗi và message lỗi
        /// </returns>
        public JsonResult ErrorLogin()
        {
            int code = 403;
            int message = 26; //Bạn cần đăng nhập để tiếp tục
            return Json(new { code, message }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Trả về thông báo lỗi nếu chư không có quyền truy cập khi xử dụng ajax.
        /// Author: QuyPN - 06/05/2018 - create
        /// </summary>
        /// <returns>
        /// Chuỗi Json bao gồm mã lỗi và message lỗi
        /// </returns>
        public JsonResult NotAccessAjax()
        {
            int code = 403;
            int message = 27; //Bạn không có quyền thực hiện hành động này
            return Json(new { code, message }, JsonRequestBehavior.AllowGet);
        }
    }
}