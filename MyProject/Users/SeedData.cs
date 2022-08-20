using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Users
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var roleMgr = provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var roleName in RoleNames.AllRoles)
            {
                var role = roleMgr.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    var rezult = roleMgr.CreateAsync(new IdentityRole { Name = roleName }).Result;
                    if (!rezult.Succeeded) throw new Exception(rezult.Errors.First().Description);
                }
            }
            var userMgr = provider.GetRequiredService<UserManager<IdentityUser>>();

            var adminResult = await userMgr.CreateAsync(DefaultUsers.Administrator, "User123!");
            var userResult = await userMgr.CreateAsync(DefaultUsers.User, "Users123!");

            if (adminResult.Succeeded || userResult.Succeeded)
            {
                var adminUser = await userMgr.FindByEmailAsync(DefaultUsers.Administrator.Email);
                var connonUser = await userMgr.FindByEmailAsync(DefaultUsers.User.Email);

                await userMgr.AddToRoleAsync(adminUser, RoleNames.Administrator);
                await userMgr.AddToRoleAsync(connonUser, RoleNames.User);
            }
        }
    }
    public static class RoleNames
    {
        public const string Administrator = "Administrator";
        public const string User = "User";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Administrator;
                yield return User;
            }
        }
    }
    public static class DefaultUsers
    {
        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "Admin@test.ua",
            EmailConfirmed = true,
            UserName = "Admin@test.ua"
        };
        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "User@test.ua",
            EmailConfirmed = true,
            UserName = "User@test.ua"
        };
        public static IEnumerable<IdentityUser> AllUsers
        {
            get
            {
                yield return User;
                yield return Administrator;
            }
        }
    }
}
