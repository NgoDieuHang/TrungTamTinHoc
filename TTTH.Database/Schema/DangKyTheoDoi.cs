using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DangKyTheoDoi")]
    public partial class DangKyTheoDoi : TableHaveIdInt
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
