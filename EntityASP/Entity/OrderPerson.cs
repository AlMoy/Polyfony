using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
    {
    public class OrderPerson
        {
        #region Attributs
        private Order order;
        private Person person;
        #endregion

        #region Properties
        public Order Order
            {
            get { return order; }
            set { order = value; }
            }

        public Person Person
            {
            get { return person; }
            set { person = value; }
            }
        #endregion

        #region Constructors
        public OrderPerson()
            {
            }
        #endregion
        }
    }
