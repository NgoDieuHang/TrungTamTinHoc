using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LoaiTaiSanTrans")]
    public partial class LoaiTaiSanTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenLoaiTaiSan { get; set; }

        [Required]
        [StringLength(20)]
        public string DonViTinh { get; set; }

        public virtual LoaiTaiSan LoaiTaiSan { get; set; }
    }
}
