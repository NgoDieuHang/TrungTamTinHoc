using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("TokenLogin")]
    public partial class TokenLogin : TableHaveIdInt
    {
        public int IdAccount { get; set; }

        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        public DateTime ThoiGianTonTai { get; set; }

        public virtual Account Account { get; set; }
    }
}
