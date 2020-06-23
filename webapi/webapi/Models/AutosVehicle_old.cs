using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class AutosVehicle
    {   
        [Key]
        public int AutoId { get; set; }
        [StringLength(30)]
        public string MakeId { get; set; }
        [StringLength(30)]
        public string modlID { get; set; }
        public int bodyID { get; set; }
        [StringLength(30)]
        public string CatgID { get; set; }
        [StringLength(30)]
        public string Acolor { get; set; }
        [StringLength(30)]
        public string sellID { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(45)]
        public string statNm { get; set; }
        [StringLength(45)]
        public string cityNM { get; set; }
        [StringLength(45)]
        public string ZipCod { get; set; }
        [StringLength(45)]
        public string cnName { get; set; }
        [StringLength(45)]
        public string MILEAG { get; set; }
        [StringLength(45)]
        public string sellpri { get; set; }
        public int Auyear { get; set; }
        [StringLength(45)]
        public string transmission { get; set; }
        [StringLength(45)]
        public string fueltype { get; set; }
        public int power { get; set; }
        public int valume { get; set; }
        [StringLength(45)]
        public string Engine { get; set; }
        
        public int Seater { get; set; }
        public int Cosumption { get; set; }
        public int NoOfDoors { get; set; }

        public bool IsSold { get; set; }
        public bool IsReserved { get; set; }

    }
}
