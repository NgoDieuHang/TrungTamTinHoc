using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LichHoc")]
    public partial class LichHoc : TableHaveIdInt
    {
        public int IdLopHoc { get; set; }

        public int IdPhongHoc { get; set; }

        public int NgayHoc { get; set; }

        public TimeSpan GioBatDau { get; set; }

        public TimeSpan GioKetThuc { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }
    }
}
