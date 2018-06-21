using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LuongNhanVien")]
    public partial class LuongNhanVien  : TableHaveIdInt
    {
        public int IdUser { get; set; }

        [Column(TypeName = "money")]
        public decimal TienLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThoiGianApDung { get; set; }

        public virtual User User { get; set; }
    }
}
