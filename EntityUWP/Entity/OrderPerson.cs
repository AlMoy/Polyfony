using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class OrderPerson : EntityBase<OrderPerson>
    {
        #region Properties
        public Person Person { get; set; }
        public Order Order { get; set; }
        #endregion

        #region Functions
        public override OrderPerson Copy()
        {
            OrderPerson orderPerson = new OrderPerson();
            orderPerson.Person = this.Person;
            orderPerson.Order = this.Order;

            return orderPerson;
        }

        public override void CopyFrom(OrderPerson obj)
        {
            this.Person = obj.Person;
            this.Order = obj.Order;
        }
        #endregion
    }
}
