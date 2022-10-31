using Microsoft.AspNetCore.Identity;
using Nexus_loT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web.Services
{
    public static class SeedingService
    {
        


        public static void SeedRoles
            (RoleManager<IdentityRole> _roleManager)
        {
            string roleId = Guid.NewGuid().ToString();
            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                var adminRole = new IdentityRole
                {
                    Id = roleId,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                };

                IdentityResult roleResult = _roleManager.CreateAsync(adminRole).GetAwaiter().GetResult(); ;

            }
        }

        public static void SeedUsers
            (UserManager<User> _userManager)
        {
            string adminId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<User>();
            if (_userManager.FindByEmailAsync("admin22@yahoo.com").Result == null)
            {
                var newAdmin = new User
                {
                    Id = adminId,
                    FirstName = "Admin",
                    LastName = "Administratorr",
                    Email = "admin22@yahoo.com",
                    NormalizedEmail = "admin22@yahoo.com",
                    UserName = "admin22@yahoo.com",
                    IsActive = true,
                    //EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Adminadmin@@123"),

                    //SecurityStamp = string.Empty

                };

                IdentityResult result = _userManager.CreateAsync(newAdmin).GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(newAdmin, "Administrator").GetAwaiter().GetResult();
                }
            }
        }

        public static void SeedData(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)


        {

            SeedRoles(_roleManager);
            SeedUsers(_userManager);
            


        }

    }
}
        

