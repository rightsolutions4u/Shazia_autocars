using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Vehiclefeatures
    {

        [Key]
        [StringLength(50)]
        public string FEATID { get; set; }
        [StringLength(100)]
        public string FTDESC { get; set; }
    }
}
