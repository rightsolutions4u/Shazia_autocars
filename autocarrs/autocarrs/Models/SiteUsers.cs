using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class SiteUsers
    {
        // public int Id { get; set; }
        public string UserId { get; set; }
        public string UserFName { get; set; }
        public string UserMName { get; set; }
        public string UserLName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string UserType { get; set; }
        public DateTime RegDate { get; set; }
    }
}