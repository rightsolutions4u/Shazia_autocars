using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using autocarrs.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;
using System.Dynamic;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;

namespace autocarrs.Models
{
    public class Load
    {
        [Key]
        public int AutoId { get; set; }
        public IEnumerable<AutosVehicle> AutosVehicleF { get; set; }
        public IEnumerable<AutosVehicle> AutosVehicleT { get; set; }
        public IEnumerable<CarMake> CarMake { get; set; }
        public IEnumerable<CarBody> CarBody { get; set; }
        public IEnumerable<CarCategory> CarCategory { get; set; }
        public IEnumerable<CarModel> CarModel { get; set; }

    }
}