using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("Group")]
    public partial class Group : TableHaveIdInt
    {
        public Group()
        {
            GroupOfAccount = new HashSet<GroupOfAccount>();
            GroupTrans = new HashSet<GroupTrans>();
            Permission = new HashSet<Permission>();
        }

        public bool IsDefault { get; set; }

        public bool IsSystem { get; set; }
        
        public virtual ICollection<GroupOfAccount> GroupOfAccount { get; set; }
        
        public virtual ICollection<GroupTrans> GroupTrans { get; set; }
        
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
