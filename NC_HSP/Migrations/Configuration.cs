namespace NC_HSP.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NC_HSP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NC_HSP.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            //assign me to the Admin role, if not already in it
            var uStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(uStore);

            if (userManager.FindByEmail("admin@hsp.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "admin@hsp.com",
                    Email = "admin@hsp.co",
                    FirstName = "Admin",
                    LastName = ""
                }, "Password-1");
            }
            //assign me to the Admin role, if not already in it
            var userId = userManager.FindByEmail("admin@hsp.com").Id;
            if (!userManager.IsInRole(userId, "Admin"))
            {
                userManager.AddToRole(userId, "Admin");
            }

        }
    }
}
