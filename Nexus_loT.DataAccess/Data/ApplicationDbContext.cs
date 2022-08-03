using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nexus_loT.Models;
using System;

namespace Nexus_loT.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
    
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Reading> Readings { get; set; }
    }
}
