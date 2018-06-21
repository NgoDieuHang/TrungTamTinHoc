using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DiemDanh")]
    public partial class DiemDanh : TableHaveIdInt
    {
        public int IdHocVien { get; set; }

        public DateTime NgayDiHoc { get; set; }

        public bool VangHoc { get; set; }

        public int? IdLopBoSung { get; set; }

        public DateTime? NgayBoSung { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
