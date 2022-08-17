using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



    //    public void Seed(ModelBuilder modelBuilder)
    //    {
    //        string adminId = Guid.NewGuid().ToString();
    //        string roleId = Guid.NewGuid().ToString();
    //        var hasher = new PasswordHasher<User>();

    //        //if (!_roleManager.RoleExistsAsync("Administrator").Result)
    //        //{
    //        //    var adminRole = new IdentityRole
    //        //    {
    //        //        Id = roleId,
    //        //        Name = "Administrator",
    //        //        NormalizedName = "ADMINISTRATOR"
    //        //    };

    //        //    IdentityResult roleResult = _roleManager.CreateAsync(adminRole).GetAwaiter().GetResult(); ;

    //        //}
    //        //else if (_userManager.FindByEmailAsync("admin22@yahoo.com").Result == null)
    //        //{
    //        //    var newAdmin = new User
    //        //    {
    //        //        Id = adminId,
    //        //        FirstName = "Admin",
    //        //        LastName = "Administratorr",
    //        //        Email = "admin22@yahoo.com",
    //        //        //NormalizedEmail = "admin22@yahoo.com",
    //        //        IsActive = true,
    //        //        //EmailConfirmed = true,
    //        //        PasswordHash = hasher.HashPassword(null, "Adminadmin@@123"),
    //        //        //SecurityStamp = string.Empty
    //        //    };

    //        //    IdentityResult result =  _userManager.CreateAsync(newAdmin).GetAwaiter().GetResult();

    //        //    if (result.Succeeded)
    //        //    {
    //        //        _userManager.AddToRoleAsync(newAdmin, "Administrator").GetAwaiter().GetResult();
    //        //    }
    //        //}


    //        //============================================================================================================


    //        //modelBuilder.Entity<IdentityRole>()
    //        //    .HasData(
    //        //        new IdentityRole
    //        //        {
    //        //            Id = roleId,
    //        //            Name = "Administrator",
    //        //            NormalizedName = "ADMINISTRATOR"
    //        //        }

    //        //    );



    //        //modelBuilder.Entity<User>()
    //        //    .HasData(
    //        //        new User
    //        //        {
    //        //            Id = adminId,
    //        //            FirstName = "Admin",
    //        //            LastName = "Administratorr",
    //        //            Email = "admin22@yahoo.com",
    //        //            //NormalizedEmail = "admin22@yahoo.com",
    //        //            IsActive = true,
    //        //            //EmailConfirmed = true,
    //        //            PasswordHash = hasher.HashPassword(null, "Adminadmin@@123"),
    //        //            //SecurityStamp = string.Empty
    //        //        }

    //        //    );

    //        //modelBuilder.Entity<IdentityUserRole<string>>()
    //        //    .HasData(
    //        //        new IdentityUserRole<string>
    //        //        {
    //        //            RoleId = roleId,
    //        //            UserId = adminId
    //        //        }

    //        //    );

    //        //============================================================================================================

    //        //if (!_dbContext.Roles.Any())
    //        //{
    //        //    var roles = new List<IdentityRole>()
    //        //    {
    //        //            new IdentityRole
    //        //        {
    //        //            Id = roleId,
    //        //            Name = "Administrator",
    //        //            NormalizedName = "ADMINISTRATOR"
    //        //        }
    //        //    };

    //        //    _dbContext.Roles.AddRange(roles);
    //        //    _dbContext.SaveChanges();
    //        //}

    //        //if (!_dbContext.Users.Any())
    //        //{
    //        //    var user = new User()
    //        //    {

    //        //        Id = adminId,
    //        //        FirstName = "Admin",
    //        //        LastName = "Administratorr",
    //        //        Email = "admin22@yahoo.com",
    //        //        //NormalizedEmail = "admin22@yahoo.com",
    //        //        IsActive = true,
    //        //        //EmailConfirmed = true,
    //        //        PasswordHash = hasher.HashPassword(null, "Adminadmin@@123"),
    //        //        //SecurityStamp = string.Empty

    //        //    };

    //        //    _dbContext.Users.AddRange(user);
    //        //    _dbContext.SaveChanges();
    //        //}

    //        //if (!_dbContext.UserRoles.Any())
    //        //{
    //        //    var userRole = new IdentityUserRole<string>()
    //        //    {

    //        //        RoleId = roleId,
    //        //        UserId = adminId

    //        //    };

    //        //    _dbContext.UserRoles.AddRange(userRole);
    //        //    _dbContext.SaveChanges();
    //        //}
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        Seed(modelBuilder);
    //    }
    }

    
}
