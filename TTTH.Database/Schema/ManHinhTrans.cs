using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ManHinhTrans")]
    public partial class ManHinhTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenManHinh { get; set; }

        [Required]
        [StringLength(500)]
        public string MoTa { get; set; }

        public virtual ManHinh ManHinh { get; set; }
    }
}
