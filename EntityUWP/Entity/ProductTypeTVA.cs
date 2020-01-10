using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class ProductTypeTVA : EntityBase<ProductTypeTVA>
    {
        #region Attributs
        private long id;
        private ProductType productType;
        private TVA tva;
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
        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; OnPropertyChanged("ProductType"); }
        }

        [Required]
        public TVA TVA
        {
            get { return tva; }
            set { tva = value; OnPropertyChanged("TVA"); }
        }
        #endregion

        #region Functions
        public override ProductTypeTVA Copy()
        {
            ProductTypeTVA productTypeTVA = new ProductTypeTVA();
            productTypeTVA.Id = this.Id;
            productTypeTVA.ProductType = this.ProductType;
            productTypeTVA.TVA = this.TVA;

            return productTypeTVA;
        }

        public override void CopyFrom(ProductTypeTVA obj)
        {
            this.Id = obj.Id;
            this.ProductType = obj.ProductType;
            this.TVA = obj.TVA;
        }
        #endregion
    }
}