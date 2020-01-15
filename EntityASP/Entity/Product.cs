using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
{
    public class Product
    {
        #region Attributs
        private long id;
        private string size;
        private string name;
        private float weight;
        private string color;
        private long quantity;
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
        [Display(Name = "Nom")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Required]
        [Display(Name = "Taille")]
        [Column("pr_size")]
        [DataType(DataType.Text)]
        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        [Required]
        [Display(Name = "Masse")]
        [Column("pr_weight")]
        [Range(typeof(float), "0", "20")]
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        [Required]
        [Display(Name = "Couleur")]
        [Column("pr_color")]
        [DataType(DataType.Text)]
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        [Required]
        [Display(Name = "Quantité")]
        [Column("pr_quantity")]
        [Range(typeof(long), "0", "100000")]
        public long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [Required]
        [Display(Name = "Validé")]
        [Column("pr_toValid")]
        public Boolean ToValid
        {
            get { return toValid; }
            set { toValid = value; }
        }

        public virtual List<ProductStateProduct> ProductStateProducts
        {
            get { return productStateProducts; }
            set { productStateProducts = value; }
        }

        [JsonIgnore]
        public List<ProductOrder> ProductOrders
        {
            get { return productOrders; }
            set { productOrders = value; }
        }

        [Display(Name = "Type")]
        public virtual ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
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
        public override string ToString()
            {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
        #endregion
    }
}