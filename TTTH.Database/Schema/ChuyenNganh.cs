using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("ChuyenNganh")]
    public partial class ChuyenNganh : TableHaveIdInt
    {
        public ChuyenNganh()
        {
            ChuyenNganhTrans = new HashSet<ChuyenNganhTrans>();
            KhoaHoc = new HashSet<KhoaHoc>();
        }

        public int IdLinhVuc { get; set; }

        public virtual LinhVuc LinhVuc { get; set; }
        
        public virtual ICollection<ChuyenNganhTrans> ChuyenNganhTrans { get; set; }
        
        public virtual ICollection<KhoaHoc> KhoaHoc { get; set; }
    }
}
