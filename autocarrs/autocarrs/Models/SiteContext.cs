using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using autocarrs.Models;

namespace autocarrs.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options)
            : base(options)
        {

        }
        
        public DbSet<SiteUsers> SiteUsers { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        public DbSet<AutosVehicle> AutosVehicle { get; set; }
        public DbSet<AdminUserRoles> adminuserroles { get; set; }
        //public DbSet<AdminUsers> AdminUsers { get; set; }
        //public DbSet<AutosBuyer> autosbuyer { get; set; }
        //public DbSet<AutosSeller> autosseller { get; set; }
        public DbSet<CarBody> carbody { get; set; }
        public DbSet<CarCategory> CarCategory { get; set; }
        public DbSet<CarMake> carmake { get; set; }
        public DbSet<CarModel> carmodel { get; set; }
        public DbSet<OrderDetails> orderdetails { get; set; }
        public DbSet<OrderMaster> ordermaster { get; set; }
        //public DbSet<webapi.Models.Vehiclefeatures> vehiclefeatures { get; set; }
    }
}
