using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Xa")]
    public partial class Xa : Table
    {
        public Xa()
        {
            User = new HashSet<User>();
        }

        [Key]
        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(3)]
        public string IdHuyen { get; set; }

        [Required]
        [StringLength(50)]
        public string TenXa { get; set; }

        public virtual Huyen Huyen { get; set; }
        
        public virtual ICollection<User> User { get; set; }
    }
}
