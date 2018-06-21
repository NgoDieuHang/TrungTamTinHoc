using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ThongTinBoSungTrans")]
    public partial class ThongTinBoSungTrans : TableHaveLang
    {
        [Required]
        public string MoTaBanThan { get; set; }

        public virtual ThongTinBoSung ThongTinBoSung { get; set; }
    }
}
