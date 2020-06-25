using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace autocarrs.Models
{
    public class AutosImages
    {
        [Key]
        public int ImageID { get; set; }
        //[Foreign key
        public int AutosID { get; set; }
        [StringLength(200)]
        public string ImgURL { get; set; }
    }
}