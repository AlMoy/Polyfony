
﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class ProductStateProduct : EntityBase<ProductStateProduct>
        {

        #region Attributs
        private long id;
        private long productId;
        private long stateProductId;
        private Product product;
        private StateProduct stateProduct;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [ForeignKey(typeof(Product))]
        public long ProductId
        {
            get { return productId; }
            set { productId = value; }
        }


        [NotNull]
        [ManyToOne("ProductId")]
        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }

        [ForeignKey(typeof(StateProduct))]
        public long StateProductId
        {
            get { return stateProductId; }
            set { stateProductId = value; }
        }

        [NotNull]
        [ManyToOne("StateProductId")]
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
            productStateProduct.ProductId = this.ProductId;
            productStateProduct.StateProductId = this.StateProductId;
            productStateProduct.Product = this.Product;
            productStateProduct.StateProduct = this.StateProduct;

            return productStateProduct;

            }

        public override void CopyFrom(ProductStateProduct obj)
            {
            this.Id = obj.Id;
            this.ProductId = obj.ProductId;
            this.StateProductId = obj.StateProductId;
            this.Product = obj.Product;
            this.StateProduct = obj.StateProduct;
            }
        #endregion
        }
    }
