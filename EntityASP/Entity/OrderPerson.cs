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
        private long id;
        private Order order;
        private Person person;
        #endregion

        #region Properties
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

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
