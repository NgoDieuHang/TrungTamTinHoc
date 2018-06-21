using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TTTH.DataBase
{
    public class Table
    {
        public DateTime? Created_at { set; get; }
        public int Created_by { set; get; }
        public DateTime? Updated_at { set; get; }
        public int Updated_by { set; get; }
        public bool DelFlag { set; get; }
    }
    public class TableHaveIdInt : Table
    {
        [Key]
        [Column(Order = 0)]
        public int Id { set; get; }
    }
    public class TableHaveIdString : Table
    {
        [Key]
        [MaxLength(10)]
        [Column(Order = 0)]
        public string Id { set; get; }
    }
    public class TableHaveLang : Table
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }
        [Key]
        [Column(Order = 1)]
        [MaxLength(5)]
        public string Lang { set; get; }
    }
}