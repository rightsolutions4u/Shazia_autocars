using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace autocarrs.Models
{
    public class AdminUserRoles
    {
        [Key]
        [StringLength(50)]
        public string AdminUserId { get; set; }
        [StringLength(50)]
        public int RoleId { get; set; }
    }
}
