using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class AutosFeatuers
    {
        [Key]
        public int AuFeId { get; set; }
        [StringLength(70)]
        [Display(Name = "Features")]
        public string AuDesc { get; set; }
        //Foreign Key
        [StringLength(45)]
        public string FEATID { get; set; }
        //Foreign Key
        public int AutoId { get; set; }
        //Navigation Property
        public Vehiclefeatures Vehiclefeatures { get; set; }
    }
}