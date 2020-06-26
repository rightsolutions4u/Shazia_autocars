using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class SiteUsers
    {
        // public int Id { get; set; }
        [Key]
        [StringLength(50)]
        public string UserId { get; set; }
        [StringLength(50)]
        public string UserFName { get; set; }
        [StringLength(50)]
        public string UserMName { get; set; }
        [StringLength(50)]
        public string UserLName { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        [StringLength(50)]
        public string UserType { get; set; }
        public DateTime  RegDate { get; set; }
    }
}
