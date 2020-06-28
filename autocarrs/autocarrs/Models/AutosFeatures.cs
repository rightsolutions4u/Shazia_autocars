using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class AutosFeatures
    {
        [Key]
        public int AuFeId { get; set; }
        [StringLength(70)]
        [Display(Name = "Features")]
        public string AuDesc { get; set; }
        //Foreign Key
        public int FEATID { get; set; }
        //Foreign Key
        public int AutoId { get; set; }
        //Navigation Property
        public AutosVehicle AutosVehicle { get; set; }
        public Vehiclefeatures Vehiclefeatures { get; set; }
    }
}