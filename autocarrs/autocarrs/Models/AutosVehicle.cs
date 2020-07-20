using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using System.Data.Entity.Include;

namespace autocarrs.Models
{
    public class AutosVehicle
    {
        // [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)] //user supplied value
        [Key]
        public int AutoId { get; set; }
        [StringLength(30)]
        public string Acolor { get; set; }
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(45)]
        public string StatNm { get; set; }
        [StringLength(45)]
        public string CityNm { get; set; }
        [StringLength(45)]
        public string ZipCod { get; set; }
        [StringLength(45)]
        public string CnName { get; set; }
        public int Mileag { get; set; }
        public int SellPri { get; set; }
        public int AuYear { get; set; }
        [StringLength(45)]
        public string FuelType { get; set; }
        [StringLength(45)]
        public string Transmission { get; set; }
        public int Power { get; set; }
        public int Volume { get; set; }
        [StringLength(45)]
        public string Engine { get; set; }
        public int Seater { get; set; }
        public int Cosumption { get; set; }
        public int NoOfDoors { get; set; }
        public int IsSold { get; set; }
        public int IsReserved { get; set; }
        public int IsFeatured { get; set; }
        public int IsTrendy { get; set; }
        [StringLength(2000)]
       
        // Foreign Key
        public string MakeId { get; set; }
        // Foreign Key
        public string ModlId { get; set; }
        // Foreign Key
        public string BodyId { get; set; }
        // Foreign Key
        public string CatgId { get; set; }
        // Foreign Key
        public string SellID { get; set; }
        //Navigation property
        public CarMake CarMake { get; set; }
        //Navigation property
        public CarModel CarModel { get; set; }
        //Navigation property
        public CarBody CarBody { get; set; }
        //Navigation property
        public CarCategory CarCategory { get; set; }
        public ICollection<AutosImages> AutosImages { get; set; }
        public ICollection<AutosFeatuers> AutosFeatures { get; set; }

        public static implicit operator AutosVehicle(ActionResult v)
        {
            throw new NotImplementedException();
        }
    }
}
