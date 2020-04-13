using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@localhost"
                };

                var result = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, RoleTypes.Administrator.ToString()).Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            //Loop through all roles and add if they do not exist
            foreach (RoleTypes role in (RoleTypes[])Enum.GetValues(typeof(RoleTypes)))
            {
                if (!roleManager.RoleExistsAsync(role.ToString()).Result)
                {
                    var newRole = new IdentityRole
                    {
                        Name = role.ToString()
                    };

                    var result = roleManager.CreateAsync(newRole).Result;
                }
            }
        }

        //Add roles here
        public enum RoleTypes
        {
            Administrator = 1,
            Employee
        }
    }
}
