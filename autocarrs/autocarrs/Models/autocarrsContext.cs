using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace autocarrs.Models
{
    public class autocarrsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public autocarrsContext() : base("name=autocarrsContext")
        {
        }

        public System.Data.Entity.DbSet<autocarrs.Models.AutosVehicle> AutosVehiclesCrollers { get; set; }

        public System.Data.Entity.DbSet<autocarrs.Models.CarBody> CarBodies { get; set; }

        public System.Data.Entity.DbSet<autocarrs.Models.CarCategory> CarCategories { get; set; }

        public System.Data.Entity.DbSet<autocarrs.Models.CarMake> CarMakes { get; set; }

        public System.Data.Entity.DbSet<autocarrs.Models.CarModel> CarModels { get; set; }

        public System.Data.Entity.DbSet<autocarrs.Models.AutosImages> AutosImages { get; set; }
        public System.Data.Entity.DbSet<autocarrs.Models.AutosFeatuers> AutosFeatuers { get; set; }
    }
}
