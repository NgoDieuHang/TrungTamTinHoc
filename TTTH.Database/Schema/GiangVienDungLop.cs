using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("GiangVienDungLop")]
    public partial class GiangVienDungLop : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public int IdLopHoc { get; set; }

        public DateTime ThoiGianBatDauDay { get; set; }

        public DateTime? ThoiGianKetThucDay { get; set; }

        public double SoTietDaDay { get; set; }

        [Column(TypeName = "money")]
        public decimal SoTienMoiTiet { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual User User { get; set; }
    }
}
