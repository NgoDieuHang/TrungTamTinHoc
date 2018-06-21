using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Tinh")]
    public partial class Tinh : Table
    {
        public Tinh()
        {
            Huyen = new HashSet<Huyen>();
        }

        [Key]
        [StringLength(2)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTinh { get; set; }
        
        public virtual ICollection<Huyen> Huyen { get; set; }
    }
}
