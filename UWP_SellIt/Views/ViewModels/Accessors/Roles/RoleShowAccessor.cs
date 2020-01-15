using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Views.ViewModels.Accessors.Roles
{
    public class RoleShowAccessor
    {
        public Role Role { get; set; }

        public RoleShowAccessor()
        {
            this.Role = new Role();
        }
    }
}
