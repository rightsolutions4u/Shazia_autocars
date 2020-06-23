using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string RoleDesc { get; set; }
    }
}
