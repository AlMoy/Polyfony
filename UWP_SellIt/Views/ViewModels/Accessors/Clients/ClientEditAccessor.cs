using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Clients
{
    public class ClientEditAccessor
    {
        public Person Client { get; set; }
        public ButtonAccessor Button { get; set; }
        public ClientEditAccessor()
        {
            this.Client = new Person();
            this.Button = new ButtonAccessor();
        }
    }
}
