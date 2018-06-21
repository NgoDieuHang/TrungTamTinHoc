using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ThanhToanLuong")]
    public partial class ThanhToanLuong : TableHaveIdInt
    {
        public int IdUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime LuongCuaThang { get; set; }

        [Column(TypeName = "money")]
        public decimal TongLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal ThueTNCN { get; set; }

        [Column(TypeName = "money")]
        public decimal BaoHiem { get; set; }

        public bool DaNhanLuong { get; set; }

        public virtual User User { get; set; }
    }
}
