using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Orders
{
    public class OrderListAccessor
    {

        public ObservableCollection<Order> Clients { get; set; }
        public ListViewAccessor<Order> ListView { get; set; }

        public OrderListAccessor()
        {
            this.Clients = new ObservableCollection<Order>();
            this.ListView = new ListViewAccessor<Order>();
        }
    }
}
