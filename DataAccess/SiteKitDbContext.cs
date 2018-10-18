using Domain;
using System;
using System.Data.Entity;

namespace DataAccess
{
    public class SiteKitDbContext:DbContext
    {
        public SiteKitDbContext(string name= "SiteKitDbContext") : base(name)
        {
            Database.SetInitializer(new SiteKitDbContextInitializer());
        }
        public DbSet<BmiCategory> BmiCategories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Bmi> Bmis { get; set; }
    }
}
