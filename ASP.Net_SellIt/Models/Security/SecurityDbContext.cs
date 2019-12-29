using ASP.Net_SellIt;
using AuthentificationTp.Utils.IdentityUtils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ASP.Net_SellIt.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_SellIt.Models.Security
{
    public class SecurityDbContext : IdentityDbContext<MyIdentityUser>
    {
        public SecurityDbContext()
            : base("DefaultSecurityConnection", throwIfV1Schema: false)
        {
            if (this.Database.CreateIfNotExists())
            {
                IdentityRole userRole = RoleUtils.CreateOrGetRole("User");
                IdentityRole adminRole = RoleUtils.CreateOrGetRole("Admin");

                UserManager<MyIdentityUser> userManager = new ApplicationUserManager(new UserStore<MyIdentityUser>(this));
                MyIdentityUser admin = new MyIdentityUser() { UserName = "admin", Email = "admin@mysite.com", Login = "admin" };
                var result = userManager.Create(admin, "Admin!123");
                if (!result.Succeeded)
                {
                    this.Database.Delete();
                    throw new System.Exception("database insert fail");
                }
                RoleUtils.AssignRoleToUser(adminRole, admin);
            }
        }

        public static SecurityDbContext Create()
        {
            return new SecurityDbContext();
        }
    }
}