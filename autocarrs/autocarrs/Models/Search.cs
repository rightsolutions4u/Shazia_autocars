using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class Search
    {
        [StringLength(30)]
        public string Acolor { get; set; }
        public int FromMil { get; set; }
        public int ToMil { get; set; }
        public int SellPri { get; set; }
        public int AuYear { get; set; }
        [StringLength(45)]
        public string FuelType { get; set; }
        [StringLength(45)]
        public string Transmission { get; set; }
        public int PowerFrom { get; set; }
        public int PowerTo { get; set; }
        public int Volume { get; set; }
        [StringLength(45)]
        public string Engine { get; set; }
        public int Seater { get; set; }
        public int Cosumption { get; set; }
        public int NoOfDoors { get; set; }
        
        public string MakeId { get; set; }
        public string ModlId { get; set; }
        public string BodyId { get; set; }
        public string CatgId { get; set; }
        
    }
}