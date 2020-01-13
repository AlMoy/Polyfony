using EntityUWP.Entity;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class Order : EntityBase<Order>
    {
        #region Attributs
        private long id;
        private string name;
        private string description;
        private float remise;
        private DateTimeOffset datePayment;
        private DateTimeOffset dateCreation;
        private List<ProductOrder> productOrders;
        private List<OrderPerson> orderPerson;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("name")]
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }


        [Column("or_description")]
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }


        [Column("or_remise")]
        public float Remise
        {
            get { return remise; }
            set { remise = value; OnPropertyChanged("Remise"); }
        }

        [Column("or_datePayment")]
        public DateTimeOffset DatePayment
        {
            get { return datePayment; }
            set { datePayment = value; OnPropertyChanged("DatePayment"); }
        }

        [Column("or_dateCreation")]
        [NotNull]
        public DateTimeOffset DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; OnPropertyChanged("DateCreation"); }
        }

        [OneToMany]
        public List<ProductOrder> ProductOrders
        {
            get { return productOrders; }
            set { productOrders = value; OnPropertyChanged("ProductOrders"); }
        }


        [ManyToMany(typeof(Person))]
        public List<OrderPerson> OrderPerson
        {
            get { return orderPerson; }
            set { orderPerson = value; OnPropertyChanged("OrderPerson"); }
        }
        #endregion

        #region Constructors
        public Order()
        {
            this.productOrders = new List<ProductOrder>();
        }
        #endregion

        #region Functions
        public override Order Copy()
        {
            Order order = new Order();
            order.Id = this.Id;
            order.Name = this.Name;
            order.Description = this.Description;
            order.Remise = this.Remise;
            order.DatePayment = this.DatePayment;
            order.DateCreation = this.DateCreation;
            order.ProductOrders = this.ProductOrders;
            order.OrderPerson = this.OrderPerson;

            return order;
        }



        public override void CopyFrom(Order obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Description = obj.Description;
            this.Remise = obj.Remise;
            this.DatePayment = obj.DatePayment;
            this.DateCreation = obj.DateCreation;
            this.ProductOrders = obj.ProductOrders;
            this.OrderPerson = obj.OrderPerson;
        }
        #endregion
    }
}