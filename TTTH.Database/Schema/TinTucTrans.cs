using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TinTucTrans")]
    public partial class TinTucTrans : TableHaveLang
    {
        [Required]
        [StringLength(100)]
        public string TieuDe { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(200)]
        public string TomTat { get; set; }

        public virtual TinTuc TinTuc { get; set; }
    }
}
