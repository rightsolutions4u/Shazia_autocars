using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class ExtendedAutosVehicle
    {
        [Key]
        public int EAId { get; set; }
        public AutosVehicle GetAutosVehicle { get; set; }
        public AutosImages GetAutosImages { get; set; }

        //public Vehiclefeatures GetVehiclefeatures { get; set; }

    }
}
