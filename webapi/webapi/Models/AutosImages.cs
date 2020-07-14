using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class AutosImages
    {
        [Key]
        public int ImageID { get; set; }
       //[Foreign key
        public int AutoId { get; set; }
        [StringLength(200)]
        public string ImgURL { get; set; }
    }
}
