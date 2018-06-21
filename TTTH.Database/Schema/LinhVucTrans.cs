using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("LinhVucTrans")]
    public partial class LinhVucTrans : TableHaveLang
    {
        [Required]
        [StringLength(50)]
        public string TenLinhVuc { get; set; }

        [Required]
        [StringLength(500)]
        public string TomTat { get; set; }

        [Required]
        public string ChiTiet { get; set; }

        public virtual LinhVuc LinhVuc { get; set; }
    }
}
