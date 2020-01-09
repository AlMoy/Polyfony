using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_SellIt.Entities
{
    public class Product
        {
        #region Attributs
        private long id;
        private float size;
        private string name;
        private float weight;
        private string color;
        private ulong quantity;
        private Boolean toValid;
        private List<StateProduct> stateProducts;
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
            set { name = value; }
            }

        [Required]
        [Column("pr_size")]
        public float Size
            {
            get { return size; }
            set { size = value; }
            }

        [Required]
        [Column("pr_weight")]
        public float Weight
            {
            get { return weight; }
            set { weight = value; }
            }

        [Required]
        [Column("pr_color")]
        [DataType(DataType.Text)]
        public string Color
            {
            get { return color; }
            set { color = value; }
            }

        [Required]
        [Column("pr_quantity")]
        public ulong Quantity
            {
            get { return quantity; }
            set { quantity = value; }
            }

        [Required]
        [Column("pr_toValid")]
        public Boolean ToValid
            {
            get { return toValid; }
            set { toValid = value; }
            }
        public List<StateProduct> StateProducts
            {
            get { return stateProducts; }
            set { stateProducts = value; }
            }

        public List<ProductOrder> ProductOrders
            {
            get { return productOrders; }
            set { productOrders = value; }
            }

        public ProductType ProductType
            {
            get { return productType; }
            set { productType = value; }
            }
        #endregion

        #region Constructors
        public Product()
            {
            this.stateProducts = new List<StateProduct>();
            this.productOrders = new List<ProductOrder>();
            }
        #endregion
        }
    }
