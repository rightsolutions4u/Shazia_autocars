using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class AutosWithImages
    {
       public IEnumerable<AutosVehicle> AutosVehicle { get; set; }
       public IEnumerable<AutosImages> AutosImages { get; set; }
    }
}
