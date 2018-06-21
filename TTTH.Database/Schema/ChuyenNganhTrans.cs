using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ChuyenNganhTrans")]
    public partial class ChuyenNganhTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenChuyenNganh { get; set; }

        [Required]
        [StringLength(500)]
        public string TomTat { get; set; }

        [Required]
        public string ChiTiet { get; set; }

        public virtual ChuyenNganh ChuyenNganh { get; set; }
    }
}
