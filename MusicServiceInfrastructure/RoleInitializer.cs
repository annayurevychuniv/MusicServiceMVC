using Microsoft.AspNetCore.Identity;
using MusicServiceDomain.Model;

namespace MusicServiceInfrastructure
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string systemAdminEmail = "system_admin@gmail.com";
            string password = "Qwerty_1";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("system_admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("system_admin"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(systemAdminEmail) == null)
            {
                User systemAdmin = new User { Email = systemAdminEmail, UserName = systemAdminEmail };
                IdentityResult result = await userManager.CreateAsync(systemAdmin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(systemAdmin, "system_admin");
                }
            }
        }

    }

}