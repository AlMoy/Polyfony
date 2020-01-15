using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class Product : EntityBase<Product>
    {
        #region Attributs
        private long id;
        private string size;
        private string name;
        private float weight;
        private string color;
        private ulong quantity;
        private long productTypeId;
        private Boolean toValid;
        private List<StateProduct> productStateProducts;
        private List<Order> productOrders;
        private ProductType productType;
        private long productTypeId;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        [Column("pr_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [NotNull]
        [Column("pr_name")]
        public string Name
        {
            get { return name; }

            set { name = value; OnPropertyChanged("Name"); }
        }

        [NotNull]
        [Column("pr_size")]
        public string Size
        {
            get { return size; }
            set { size = value; OnPropertyChanged("Size"); }
        }

        [NotNull]
        [Column("pr_weight")]
        public float Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged("Weight"); }
        }

        [NotNull]
        [Column("pr_color")]
        public string Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged("Color"); }
        }

        [NotNull]
        [Column("pr_quantity")]
        public ulong Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }

        [NotNull]
        [Column("pr_toValid")]
        public Boolean ToValid
        {
            get { return toValid; }
            set { toValid = value; OnPropertyChanged("ToValid"); }
        }

        [ManyToMany(typeof(ProductStateProduct))]
        public List<StateProduct> ProductStateProducts
        {
            get { return productStateProducts; }
            set { productStateProducts = value; OnPropertyChanged("ProductStateProducts"); }
        }

        [ManyToMany(typeof(ProductOrder))]
        public List<Order> ProductOrders
        {
            get { return productOrders; }
            set { productOrders = value; OnPropertyChanged("ProductOrders"); }
        }


        [ForeignKey(typeof(ProductType))]
        public long ProductTypeId
        {
            get { return productTypeId; }
            set { productTypeId = value; }
        }


        [ManyToOne("ProductTypeId")]
        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; OnPropertyChanged("ProductType"); }
        }
        #endregion

        #region Constructors
        public Product()
            {
            this.productStateProducts = new List<StateProduct>();
            this.productOrders = new List<Order>();
        }
        #endregion

        #region Functions
        public override Product Copy()
        {
            Product product = new Product();
            product.Id = this.Id;
            product.Size = this.Size;
            product.Name = this.Name;
            product.Weight = this.Weight;
            product.Color = this.Color;
            product.Quantity = this.Quantity;
            product.ToValid = this.ToValid;
            product.ProductTypeId = this.ProductTypeId;
            product.ProductStateProducts = this.ProductStateProducts;
            product.ProductOrders = this.ProductOrders;
            product.ProductType = this.ProductType;

            return product;
        }

        public override void CopyFrom(Product obj)
        {
            this.Id = obj.Id;
            this.Size = obj.Size;
            this.Name = obj.Name;
            this.Weight = obj.Weight;
            this.Color = obj.Color;
            this.Quantity = obj.Quantity;
            this.ToValid = obj.ToValid;
            this.ProductTypeId = obj.ProductTypeId;
            this.ProductStateProducts = obj.ProductStateProducts;
            this.ProductOrders = obj.ProductOrders;
            this.ProductType = obj.ProductType;
        }
        #endregion
    }
}
