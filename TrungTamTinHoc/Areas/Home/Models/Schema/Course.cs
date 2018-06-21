using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    public class Course
    {
        public string Title { get; set; }
        public List<KhoaHoc> KhoaHoc { get; set; }
    }
}