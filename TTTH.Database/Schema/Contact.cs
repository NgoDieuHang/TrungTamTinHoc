using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Contact")]
    public partial class Contact : TableHaveIdInt
    {
        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public int IdTrangThai { get; set; }

        public virtual TrangThai TrangThai { get; set; }
    }
}
