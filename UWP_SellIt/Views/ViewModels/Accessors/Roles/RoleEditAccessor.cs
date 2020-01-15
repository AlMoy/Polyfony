using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Roles
{
    public class RoleEditAccessor
    {

        public Role Role { get; set; }
        public ButtonAccessor Button { get; set; }

        public RoleEditAccessor()
        {
            this.Role = new Role();
            this.Button = new ButtonAccessor();
        }

    }
}
