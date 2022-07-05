using e_commerce.Data;
using e_commerce.Data.Static;
using e_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var shopDbContext = new ShopDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ShopDbContext>>()))
        {

            

            if (!shopDbContext.Products.Any())
            {
                shopDbContext.Products.AddRange(new List<Product>()
                {
                    new Product()
                {

                    ProductName = "Macbook Pro 2022",
                    ProductImageUrl = "https://i.ibb.co/7nWnHc7/macbookpro.jpg",
                    ProductPrice = 2000.00

                },
                new Product()
                {

                    ProductName = "Dell XPS",
                    ProductImageUrl = "https://i.ibb.co/KXxJsfM/dellxps.jpg",
                    ProductPrice = 1999.00

                }
            });
                shopDbContext.SaveChanges();

            }
        }
    }
    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)

    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            //Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //Users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "admin@ecommerce.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    Fullname = "Admin User",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            string appUserEmail = "admin@ecommerce.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    Fullname = "App User",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
	}
}