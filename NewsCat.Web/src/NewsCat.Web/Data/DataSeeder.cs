using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsCat.Web.Data
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class UserDataSeed 
    {
        private FeedDataContext dataContext;

        public UserDataSeed(FeedDataContext context)
        {
            dataContext = context;
        }


        // TODO: Move this code when seed data is implemented in EF 7

        /// <summary>
        /// This is a workaround for missing seed data functionality in EF 7.0-rc1
        /// More info: https://github.com/aspnet/EntityFramework/issues/629
        /// </summary>
        /// <param name="app">
        /// An instance that provides the mechanisms to get instance of the database context.
        /// </param>
        public async void SeedData(IConfigurationSection ownerConfig)
        {
            // create roles
            var roleStore = new RoleStore<IdentityRole>(dataContext);
            var roleTasks = new List<Task>();
            string[] roles = new string[] { Constants.ROLE_OWNER, Constants.ROLE_ADMIN, Constants.ROLE_USERS };
            foreach (string role in roles)
                if (!dataContext.Roles.Any(r => role.Equals(r.Name, StringComparison.InvariantCultureIgnoreCase)))
                    roleTasks.Add(roleStore.CreateAsync(new IdentityRole(role) { NormalizedName = role.ToUpperInvariant() }));
            Task.WaitAll(roleTasks.ToArray());


            // create owner user
            var ownerUser = new ApplicationUser
            {
                UserName = Constants.USER_OWNER,
                NormalizedUserName = Constants.USER_OWNER.ToUpperInvariant(),
                Email = ownerConfig["Email"],
                NormalizedEmail = ownerConfig["Email"].ToUpperInvariant(),
                EmailConfirmed = true,
                PhoneNumber = ownerConfig["Phone"],
                PhoneNumberConfirmed = true,
                SecurityStamp = ownerConfig["SecurityStamp"]
            };
            
            if (!dataContext.Users.Any(u => u.UserName.Equals(Constants.USER_OWNER, StringComparison.InvariantCultureIgnoreCase)))
            {
                var hasher = new PasswordHasher<ApplicationUser>();
                var hash = hasher.HashPassword(ownerUser, ownerConfig["Password"]);
                ownerUser.PasswordHash = hash;

                var userStore = new UserStore<ApplicationUser>(dataContext);
                var createUserTask = userStore.CreateAsync(ownerUser);
                createUserTask.Wait();
                var createUserResult = createUserTask.Result;
                if (!createUserResult.Succeeded)
                    throw new AggregateException(createUserResult.Errors.Select(e => new Exception(e.Description)));
                
                await userStore.AddToRoleAsync(ownerUser, Constants.ROLE_OWNER.ToLowerInvariant());
            }

            await dataContext.SaveChangesAsync();
        }
    }
}
