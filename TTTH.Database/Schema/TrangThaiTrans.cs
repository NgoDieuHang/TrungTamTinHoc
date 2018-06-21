using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TrangThaiTrans")]
    public partial class TrangThaiTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenTrangThai { get; set; }

        public virtual TrangThai TrangThai { get; set; }
    }
}
