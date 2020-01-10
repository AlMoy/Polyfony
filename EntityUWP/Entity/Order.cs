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
        private DateTime datePayment;
        private DateTime dateCreation;
        private List<ProductOrder> productOrders;
        private Person client;
        private Person seller;
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
        public DateTime DatePayment
        {
            get { return datePayment; }
            set { datePayment = value; OnPropertyChanged("DatePayment"); }
        }

        [Unique]
        [Column("or_dateCreation")]
        [NotNull]
        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; OnPropertyChanged("DateCreation"); }
        }

        [Ignore]
        public List<ProductOrder> ProductOrders
        {
            get { return productOrders; }
            set { productOrders = value; OnPropertyChanged("ProductOrders"); }
        }

        [ManyToOne("ClientId")]
        public Person Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged("Client"); }
        }

        private int clientId;

        [ForeignKey(typeof(Person))]
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        private int sellerId;
        
        [ForeignKey(typeof(Person))]
        public int SellerId
        {
            get { return sellerId; }
            set { sellerId = value; }
        }

        [ManyToOne("SellerId")]
        public Person Seller
        {
            get { return seller; }
            set { seller = value; OnPropertyChanged("Seller"); }
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
            order.Client = this.Client;
            order.Seller = this.Seller;

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
            this.Client = obj.Client;
            this.Seller = obj.Seller;
        }
        #endregion
    }
}