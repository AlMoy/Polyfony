using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Clients
{
    public class ClientListAccessor
    {

        public ObservableCollection<Person> Clients { get; set; }
        public ListViewAccessor<Person> ListView { get; set; }

        public ClientListAccessor()
        {
            this.Clients = new ObservableCollection<Person>();
            this.ListView = new ListViewAccessor<Person>();
        }
    }
}
