using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CarBody
    {
        [Key]
        [StringLength(30)]
        public string BodyId { get; set; }
        [StringLength(100)]
        public string BDDesc { get; set; }
        //Navigation property
        
        
    }
}
