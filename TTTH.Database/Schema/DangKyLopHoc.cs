using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DangKyLopHoc")]
    public partial class DangKyLopHoc : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public int IdLopHoc { get; set; }

        public DateTime ThoiGianDangKy { get; set; }

        public int TrangThaiDangKy { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual User User { get; set; }
    }
}
