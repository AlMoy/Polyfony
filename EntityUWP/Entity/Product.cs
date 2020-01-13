using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class Product : EntityBase<Product>
        {
        #region Attributs
        private long id;
        private float size;
        private string name;
        private float weight;
        private string color;
        private ulong quantity;
        private Boolean toValid;
        private List<ProductStateProduct> productStateProducts;
        private List<ProductOrder> productOrders;
        private ProductType productType;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pr_id")]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        [Column("pr_name")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name
            {
            get { return name; }
            set { name = value; OnPropertyChanged("Name");  }
            }

        [Required]
        [Column("pr_size")]
        public float Size
            {
            get { return size; }
            set { size = value; OnPropertyChanged("Size"); }
            }

        [Required]
        [Column("pr_weight")]
        public float Weight
            {
            get { return weight; }
            set { weight = value; OnPropertyChanged("Weight"); }
            }

        [Required]
        [Column("pr_color")]
        [DataType(DataType.Text)]
        public string Color
            {
            get { return color; }
            set { color = value; OnPropertyChanged("Color"); }
            }

        [Required]
        [Column("pr_quantity")]
        public ulong Quantity
            {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
            }

        [Required]
        [Column("pr_toValid")]
        public Boolean ToValid
            {
            get { return toValid; }
            set { toValid = value; OnPropertyChanged("ToValid"); }
            }
        public List<ProductStateProduct> ProductStateProducts
            {
            get { return productStateProducts; }
            set { productStateProducts = value; OnPropertyChanged("ProductStateProducts"); }
            }

        public List<ProductOrder> ProductOrders
            {
            get { return productOrders; }
            set { productOrders = value; OnPropertyChanged("ProductOrders"); }
            }

        public ProductType ProductType
            {
            get { return productType; }
            set { productType = value; OnPropertyChanged("ProductType"); }
            }
        #endregion

        #region Constructors
        public Product()
            {
            this.productStateProducts = new List<ProductStateProduct>();
            this.productOrders = new List<ProductOrder>();
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
            this.ProductStateProducts = obj.ProductStateProducts;
            this.ProductOrders = obj.ProductOrders;
            this.ProductType = obj.ProductType;
            }
        #endregion
        }
    }
