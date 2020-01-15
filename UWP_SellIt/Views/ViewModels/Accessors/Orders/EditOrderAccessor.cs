using EntityUWP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SellIt.Views.ViewModels.Accessors.Commons;

namespace UWP_SellIt.Views.ViewModels.Accessors.Orders
{
    public class EditOrderAccessor
    {

        public Order Order { get; set; }
        public ButtonAccessor Button { get; set; }
        public EditOrderAccessor()
        {
            this.Order = new Order();
            this.Button = new ButtonAccessor();
        }
    }
}
