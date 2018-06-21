using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ChucNangTrans")]
    public partial class ChucNangTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenChucMang { get; set; }

        [Required]
        [StringLength(500)]
        public string MoTa { get; set; }

        public virtual ChucNang ChucNang { get; set; }
    }
}
