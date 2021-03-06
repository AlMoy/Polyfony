﻿using ASP.Net_SellIt.Models;
using EntityASP;
using EntityASP.Entity;
using EntityASP.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(ASP.Net_SellIt.Startup))]
namespace ASP.Net_SellIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateRolesAndUsers();
        }

        // This method create default User roles and Admin user for login    
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            using (AppDbContext contextDb = new AppDbContext())
                {
                if (!contextDb.Database.Exists())
                    {
                    contextDb.Database.Create();
                    contextDb.Initialize();
                    }
                    
                }

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {  
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
                     
            // Creating Seller role     
            if (!roleManager.RoleExists("Vendeur"))
            {
                var role = new IdentityRole();
                role.Name = "Vendeur";
                roleManager.Create(role);

            }

            // Creating Client role     
            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);

            }
        }
    }
}
