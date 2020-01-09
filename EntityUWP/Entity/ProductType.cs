using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class ProductType : EntityBase<ProductType>
    {
        #region Attributs
        private long id;
        private float price;
        private string name;
        private List<ProductTypeTVA> productTypeTVAs;
        private List<Product> products;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pt_id")]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        [Column("pt_price")]
        public float Price
            {
            get { return price; }
            set { price = value; }
            }

        [Required]
        [Column("pt_name")]
        [DataType(DataType.Text)]
        public string Name
            {
            get { return name; }
            set { name = value; }
            }

        public List<ProductTypeTVA> ProductTypeTVAs
            {
            get { return productTypeTVAs; }
            set { productTypeTVAs = value; }
            }

        public List<Product> Products
            {
            get { return products; }
            set { products = value; }
            }
        #endregion

        #region Constructors
        public ProductType()
            {
            this.productTypeTVAs = new List<ProductTypeTVA>();
            this.products = new List<Product>();
            }
        #endregion

        #region Functions
        public override ProductType Copy()
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

        public override void CopyFrom(ProductType obj)
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
