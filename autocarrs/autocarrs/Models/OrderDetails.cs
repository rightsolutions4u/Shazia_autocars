using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autocarrs.Models
{
    public class OrderDetails
    {
        [StringLength(30)]
        public string AutoID { get; set; }
        [StringLength(30)]
        public string BUYRID { get; set; }
        [StringLength(1)]
        public DateTime PURDAT { get; set; }
        public int PURAMT { get; set; }
        public string PURTYP { get; set; }
        [Key]
        [Column(Order = 1)]
        public int TRREFN { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime TRDATE { get; set; }
        public int INVNUM { get; set; }
        [StringLength(30)]
        public string CRDNUM { get; set; }
        public DateTime CRDEXP { get; set; }
        [StringLength(1)]
        public string CRDTYP { get; set; }
        [StringLength(3)]
        public string CRDCRV { get; set; }
        
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<OrderDetails>()
    //        .HasKey(c => new { c.TRREFN, c.TRDATE });
    //}
}
