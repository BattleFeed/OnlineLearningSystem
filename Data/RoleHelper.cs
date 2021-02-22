using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearningSystem.Data
{
    public class RoleHelper
    {
        public static async Task Initialize(IServiceProvider service)
        {
            using var serviceScope = service.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<UserContext>();

            await context.Database.EnsureCreatedAsync();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!context.Roles.Any(u => u.Name == "Admin"))
            {
                // Add Roles to Database
                if (await roleManager.FindByNameAsync("Admin") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
            }
        }
    }
}
