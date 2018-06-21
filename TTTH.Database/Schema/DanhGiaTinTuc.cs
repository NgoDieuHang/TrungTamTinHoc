using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DanhGiaTinTuc")]
    public partial class DanhGiaTinTuc : TableHaveIdInt
    {
        public int? IdUser { get; set; }

        public int IdTinTuc { get; set; }

        public int DiemDanhGIa { get; set; }

        public virtual TinTuc TinTuc { get; set; }

        public virtual User User { get; set; }
    }
}
