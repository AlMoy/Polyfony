using SQLite;
using System;
using System.Collections.Generic;
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
        [PrimaryKey, AutoIncrement]
        [Column("sp_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [NotNull]
        [Column("sp_name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Ignore]
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