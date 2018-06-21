using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DangKyDayBu")]
    public partial class DangKyDayBu : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public int IdLopHoc { get; set; }

        public int IdPhongHoc { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public int IdTrangThai { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual User User { get; set; }
    }
}
