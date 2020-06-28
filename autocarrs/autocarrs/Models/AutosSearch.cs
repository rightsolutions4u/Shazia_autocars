using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace autocarrs.Models
{
    public class AutosSearch //is based on 2 models
    {
        [Key]
        public int AutoId { get; set; }
        public AutosVehicle AutosVehicle { get; set; }
        public AutosFeatures AutosFeatures { get; set; }

    }
}