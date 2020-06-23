using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class AutosBuyer
    {
        [Key]
        [StringLength(30)]
        public string BuyrID { get; set; }
        [StringLength(45)]
        public string FsName { get; set; }
        [StringLength(45)]
        public string LsName { get; set; }
        [StringLength(45)]
        public string EmalID { get; set; }
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
        [StringLength(20)]
        public string HomePn { get; set; }
        [StringLength(20)]
        public string WorkPn { get; set; }
        [StringLength(20)]
        public string CellPn1 { get; set; }
        [StringLength(20)]
        public string CellPn2 { get; set; }
        [StringLength(20)]
        public string BuType { get; set; }
        public int AutoId { get; set; }

    }
}
