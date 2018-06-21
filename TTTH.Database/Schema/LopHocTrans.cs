using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LopHocTrans")]
    public partial class LopHocTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenLop { get; set; }

        [Required]
        public string ChiTiet { get; set; }

        [Required]
        [StringLength(500)]
        public string TomTat { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
