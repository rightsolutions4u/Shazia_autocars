using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CarModel
    {
        [Key]
        [StringLength(30)]
        public string ModlId { get; set; }
        [StringLength(100)]
        public string MdDesc { get; set; }
        //[Foreign key
        public string MakeId { get; set; }
      
    }
}
