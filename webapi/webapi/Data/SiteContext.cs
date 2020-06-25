using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using System.Data;

namespace webapi.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options)
            : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false; // to avoid serialization issues
        }

        public DbSet<SiteUsers> SiteUsers { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<webapi.Models.AutosVehicle> AutosVehicle { get; set; }
        public DbSet<webapi.Models.AdminUserRoles> adminuserroles { get; set; }
        public DbSet<webapi.Models.AdminUsers> adminusers { get; set; }
        public DbSet<webapi.Models.AutosBuyer> autosbuyer { get; set; }
        public DbSet<webapi.Models.AutosSeller> autosseller { get; set; }
        public DbSet<webapi.Models.CarBody> carbody { get; set; }
        public DbSet<webapi.Models.CarCategory> carcategory { get; set; }
        public DbSet<webapi.Models.CarMake> carmake { get; set; }
        public DbSet<webapi.Models.CarModel> carmodel { get; set; }
        public DbSet<webapi.Models.OrderDetails> orderdetails { get; set; }
        public DbSet<webapi.Models.OrderMaster> ordoermaster { get; set; }
        public DbSet<webapi.Models.Vehiclefeatures> vehiclefeatures { get; set; }
        public DbSet<webapi.Models.AutosImages> AutosImages { get; set; }
        //public DbQuery<webapi.Models.VAutosVehicle> VAutosVehicle {get; set;}
        //Using fluent API to generate composite key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderMaster>().ToTable("orderMaster");
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>()
                .HasKey(c => new { c.TRREFN, c.TRDATE });
            modelBuilder.Entity<OrderMaster>()
               .HasKey(d => new { d.INVNUM, d.TRDATE });
            modelBuilder.Query<VAutosVehicle>().ToView("VAutosVehicle");

        }
    }
}
