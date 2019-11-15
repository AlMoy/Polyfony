using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Entity
    {
    public class Order
        {
        #region Attributs
        private long id;
        private string name;
        private string description;
        private float remise;
        private DateTime dateOrder;
        private List<ProductOrder> productOrders;
        private Person client;
        private Person seller;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("or_id")]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        [Column("or_name")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name
            {
            get { return name; }
            set { name = value; }
            }

        [Column("or_description")]
        [DataType(DataType.MultilineText)]
        public string Description
            {
            get { return description; }
            set { description = value; }
            }

        [Column("or_remise")]
        [DataType(DataType.Currency)]
        public float Remise
            {
            get { return remise; }
            set { remise = value; }
            }

        public DateTime DateOrder
            {
            get { return dateOrder; }
            set { dateOrder = value; }
            }

        public List<ProductOrder> ProductOrders
            {
            get { return productOrders; }
            set { productOrders = value; }
            }

        public Person Client
            {
            get { return client; }
            set { client = value; }
            }

        public Person Seller
            {
            get { return seller; }
            set { seller = value; }
            }
        #endregion

        #region Constructors
        public Order()
            {
            this.productOrders = new List<ProductOrder>();
            }
        #endregion
        }
    }
