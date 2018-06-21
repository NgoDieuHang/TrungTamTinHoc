using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("XepLoai")]
    public partial class XepLoai : TableHaveIdInt
    {
        public XepLoai()
        {
            DiemCuaHocVien = new HashSet<DiemCuaHocVien>();
        }

        [Required]
        [StringLength(20)]
        public string TenXepLoai { get; set; }

        public double TuDiem { get; set; }

        public double DienDiem { get; set; }
        
        public virtual ICollection<DiemCuaHocVien> DiemCuaHocVien { get; set; }
    }
}
