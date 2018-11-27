using Microsoft.AspNetCore.Identity;
using NetworkPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Data
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("test@test.com").Result == null)
            {
                AppUser user = new AppUser
                {
                    Email = "test@test.com",
                    NormalizedEmail = "TEST@TEST.COM",
                    UserName = "Test",
                    NormalizedUserName = "TEST",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                IdentityResult result = userManager.CreateAsync(user, "Test123#").Result;
                //result.Succeeded check it on debug
            }

            if (userManager.FindByEmailAsync("test2@test.com").Result == null)
            {
                AppUser user = new AppUser
                {
                    Email = "test2@test.com",
                    NormalizedEmail = "TES2T@TEST.COM",
                    UserName = "Test2",
                    NormalizedUserName = "TEST2",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                IdentityResult result = userManager.CreateAsync(user, "Test123#").Result;
                //result.Succeeded check it on debug
            }
        }
    }
}
