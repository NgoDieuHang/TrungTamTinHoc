using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("PhongHocTrans")]
    public partial class PhongHocTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }

        [Required]
        [StringLength(500)]
        public string GhiChu { get; set; }

        public virtual PhongHoc PhongHoc { get; set; }
    }
}
