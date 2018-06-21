using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("KhoaHocTrans")]
    public partial class KhoaHocTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenKhoaHoc { get; set; }

        [Required]
        [StringLength(500)]
        public string TomTat { get; set; }

        [Required]
        public string ChiTiet { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
