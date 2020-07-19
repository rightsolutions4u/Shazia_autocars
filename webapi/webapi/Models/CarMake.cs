using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CarMake
    {
        [Key]
        [StringLength(30)]
        public string MakeId { get; set; }
        [StringLength(100)]
        public string MkDesc { get; set; }
        //Navigation property
        public ICollection<CarModel> CarModel { get; set; }

    }
}
