using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LoanManagement.Domain.Entities
{
    public static class SeedAccountsData
    {
        public static async Task Initialize(IServiceProvider _IServiceProvider)
        {
            ApplicationDbContext context = _IServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = _IServiceProvider.GetRequiredService<UserManager<User>>();

            //context.Database.EnsureCreated();

            var _user = await userManager.FindByEmailAsync("bin7shyama@gmail.com");
            if (_user == null)
            {
                User user = new User()
                {
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Admin",
                    LastName = "User",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "bin7shyama@gmail.com",
                    EmailConfirmed = true,
                    IsAdmin = true,
                    Status = true,
                    LastActive = DateTime.Now,
                    PhoneNumber = "9860051313",
                    PhoneNumberConfirmed = true,
                    CreatedBy = "Seeding",
                    UpdatedBy = "Seeding"
                };
                var r = await userManager.CreateAsync(user, "Abcd1#");
                if (r.Succeeded)
                {

                }
            }
            _user = await userManager.FindByEmailAsync("test@gmail.com");
            if (_user == null)
            {
                User user = new User()
                {
                    UserName = "test",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Test",
                    LastName = "User",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "test@gmail.com",
                    EmailConfirmed = true,
                    IsAdmin = false,
                    Status = true,
                    LastActive = DateTime.Now,
                    PhoneNumber = "9860051313",
                    PhoneNumberConfirmed = true,
                    CreatedBy = "Seeding",
                    UpdatedBy = "Seeding"
                };
                var r = await userManager.CreateAsync(user, "Abcd1#");
                if (r.Succeeded)
                {

                }
            }
        }
    }
}
