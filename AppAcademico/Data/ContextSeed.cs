using AppAcademico.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAcademico.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Administrador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Profesor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Alumno.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basico.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "superadmin@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Administrador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Profesor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Alumno.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basico.ToString());
                }

            }
        }
    }
}
