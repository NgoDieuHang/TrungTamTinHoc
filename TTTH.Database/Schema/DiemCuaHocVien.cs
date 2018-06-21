using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DiemCuaHocVien")]
    public partial class DiemCuaHocVien : TableHaveIdInt
    {
        public int IdHocVien { get; set; }

        public double Diem { get; set; }

        public int HeSo { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiDiem { get; set; }

        public int IdXepLoai { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual XepLoai XepLoai { get; set; }
    }
}
