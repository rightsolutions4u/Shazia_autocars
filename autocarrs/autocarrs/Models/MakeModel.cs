using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autocarrs.Models
{
    public class MakeModel
    {
        public List<CarModel1> CarModel1 { get; set; }
        public SelectList FilterByMake { get; set; }

        public Year year { get; set; }
    }
    //Make is super set
    public class CarMake1
    {
        [Key]
        [StringLength(30)]
        public string MakeId { get; set; }
        [Display(Name ="Brand")]
        [StringLength(100)]
        public string MkDesc { get; set; }
      }
    public class CarModel1
    {
        [Key]
        [StringLength(30)]
        public string ModlId { get; set; }
        [Display(Name = "Car Model")]
        [StringLength(100)]
        public string MdDesc { get; set; }
        [StringLength(30)]
        public string MakeId { get; set; }
        public AutosVehicle CarMake1 { get; set; }


    }
    public class Year
    {
        [Key]
        public int AutoYear { get; set; }
    }
}
