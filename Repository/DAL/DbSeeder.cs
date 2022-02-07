using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public static class DbSeeder
    {
        public static async Task SeedEssentialsAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            context.Database.Migrate();

            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Moderator"));
            await roleManager.CreateAsync(new IdentityRole("User"));
            //Seed Default User
            var defaultUser = new User
            {
                FullName = "Admin",
                UserName = "AdminUsername",
                Email = "admin@admin.com",
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var result = await userManager.CreateAsync(defaultUser, "b911-h4rt-owd1");
                var reuslt = await userManager.AddToRoleAsync(defaultUser, "Admin");
            }
            await context.SaveChangesAsync();
        }
    }
}
