using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class CarCategory
    {
        [Key]
        [StringLength(30)]
        public string CatgId { get; set; }
        [StringLength(100)]
        public string CgDesc { get; set; }
    }
}
