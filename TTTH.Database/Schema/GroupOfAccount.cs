using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("GroupOfAccount")]
    public partial class GroupOfAccount : TableHaveIdInt
    {
        public int IdAccount { get; set; }

        public int IdGroup { get; set; }

        public virtual Account Account { get; set; }

        public virtual Group Group { get; set; }
    }
}
