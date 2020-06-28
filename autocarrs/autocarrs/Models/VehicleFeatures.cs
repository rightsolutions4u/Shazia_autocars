using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autocarrs.Models
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