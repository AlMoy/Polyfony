using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class OrderPerson : EntityBase<OrderPerson>
    {

        private long personId;    
        private long orderId;
        private Person person;
        private Order order;

        #region Properties

        [ForeignKey(typeof(Person))]
        public long PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        [ForeignKey(typeof(Order))]
        public long OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        [ManyToOne("PersonId")]
        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        [ManyToOne("OrderId")]
        public Order Order
        {
            get { return order; }
            set { order = value; }
        }

        #endregion

        #region Functions
        public override OrderPerson Copy()
        {
            OrderPerson orderPerson = new OrderPerson();
            orderPerson.PersonId = this.PersonId;
            orderPerson.OrderId = this.OrderId;
            orderPerson.Person = this.Person;
            orderPerson.Order = this.Order;

            return orderPerson;
        }

        public override void CopyFrom(OrderPerson obj)
        {
            this.OrderId = obj.OrderId;
            this.PersonId = obj.PersonId;
            this.Person = obj.Person;
            this.Order = obj.Order;
        }
        #endregion
    }
}
