using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Views.ViewModels.Accessors.Clients
{
    public class ClientShowAccessor
    {
        public Person Client { get; set; }

        public ClientShowAccessor()
        {
            this.Client = new Person();
        }
    }
}
