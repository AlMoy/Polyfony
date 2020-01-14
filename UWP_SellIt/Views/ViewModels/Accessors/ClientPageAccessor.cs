using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Clients;

namespace UWP_SellIt.Views.ViewModels.Accessors
{
    public class ClientPageAccessor
    {
        public ClientEditAccessor ClientEdit { get; set; }
        public ClientListAccessor ClientList { get; set; }
        public ClientShowAccessor ClientShow { get; set; }
        

        public ClientPageAccessor()
        {
            this.ClientEdit = new ClientEditAccessor();
            this.ClientList = new ClientListAccessor();
            this.ClientShow = new ClientShowAccessor();
            
        }
    }
}
