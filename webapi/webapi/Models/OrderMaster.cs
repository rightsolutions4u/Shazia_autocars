using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class OrderMaster
    {
        [StringLength(30)]
        public string BUYRID { get; set; }
        [Column(Order = 1)]
        public int INVNUM { get; set; }
        [Column(Order = 2)]
        public DateTime TRDATE { get; set; }
        public int AMOUNT { get; set; }
        public int PartialPayment { get; set; }
    }
}
