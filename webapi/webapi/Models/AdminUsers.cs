using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class AdminUsers
    {
        [Key]
        [StringLength(50)]
        public string AdminUserId { get; set; }
        [StringLength(50)]
        public string AdminUserPwd { get; set; }
    }
}
