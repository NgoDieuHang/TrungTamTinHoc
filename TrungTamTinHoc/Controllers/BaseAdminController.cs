using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTTH.Common.Filters;

namespace TrungTamTinHoc.Controllers
{
    [AdminLogin(Order = 1)]
    [Authentication(Order = 2)]
    public class BaseAdminController : Controller
    {
    }
}