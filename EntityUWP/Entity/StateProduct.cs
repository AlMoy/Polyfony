using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class StateProduct : EntityBase<StateProduct>
    {
        #region Attributs
        private long id;
        private string name;
        private List<ProductStateProduct> productStateProducts;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sp_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        [Column("sp_name")]
        [DataType(DataType.Text)]
        [MinLength(4)]
        [MaxLength(20)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<ProductStateProduct> ProductStateProducts
        {
            get { return productStateProducts; }
            set { productStateProducts = value; }
        }
        #endregion

        #region Constructors
        public StateProduct()
        {
            this.productStateProducts = new List<ProductStateProduct>();
        }
        #endregion

        #region Functions
        public override StateProduct Copy()
        {
            StateProduct stateProduct = new StateProduct();
            stateProduct.Id = this.Id;
            stateProduct.Name = this.Name;
            stateProduct.ProductStateProducts = this.ProductStateProducts;

            return stateProduct;
        }

        public override void CopyFrom(StateProduct obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.ProductStateProducts = obj.ProductStateProducts;
        }
        #endregion
    }
}