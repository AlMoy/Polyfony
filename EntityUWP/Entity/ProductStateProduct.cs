using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class ProductStateProduct : EntityBase<ProductStateProduct>
    {
        #region Attributs
        private long id;
        private Product product;
        private StateProduct stateProduct;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [Required]
        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }

        [Required]
        public StateProduct StateProduct
        {
            get { return stateProduct; }
            set { stateProduct = value; OnPropertyChanged("StateProduct"); }
        }
        #endregion

        #region Functions
        public override ProductStateProduct Copy()
        {
            ProductStateProduct productStateProduct = new ProductStateProduct();
            productStateProduct.Id = this.Id;
            productStateProduct.Product = this.Product;
            productStateProduct.StateProduct = this.StateProduct;

            return productStateProduct;
        }

        public override void CopyFrom(ProductStateProduct obj)
        {
            this.Id = obj.Id;
            this.Product = obj.Product;
            this.StateProduct = obj.StateProduct;
        }
        #endregion
    }
}