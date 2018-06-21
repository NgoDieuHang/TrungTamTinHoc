using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DanhGiaKhoaHoc")]
    public partial class DanhGiaKhoaHoc : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public int IdKhoaHoc { get; set; }

        public int DiemDanhGIa { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual User User { get; set; }
    }
}
