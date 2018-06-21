using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("CommentKhoaHoc")]
    public partial class CommentKhoaHoc : TableHaveIdInt
    {
        public CommentKhoaHoc()
        {
            ChildComment = new HashSet<CommentKhoaHoc>();
        }

        public int? IdUser { get; set; }

        public int IdKhoaHoc { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public int? IdComment { get; set; }

        public virtual ICollection<CommentKhoaHoc> ChildComment { get; set; }

        public virtual CommentKhoaHoc ParentComment { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual User User { get; set; }
    }
}
