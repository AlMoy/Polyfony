﻿using SQLite;
using System;
using System.Collections.Generic;
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
        [PrimaryKey, AutoIncrement]
        [Column("pt_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [NotNull]
        [Column("pt_price")]
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        [NotNull]
        [Column("pt_name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Ignore]
        public List<ProductTypeTVA> ProductTypeTVAs
        {
            get { return productTypeTVAs; }
            set { productTypeTVAs = value; }
        }

        [Ignore]
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
            ProductType productType = new ProductType();
            productType.Id = this.Id;
            productType.Price = this.Price;
            productType.Name = this.Name;
            productType.ProductTypeTVAs = this.ProductTypeTVAs;
            productType.Products = this.products;

            return productType;
        }

        public override void CopyFrom(ProductType obj)
        {
            this.Id = obj.Id;
            this.Price = obj.Price;
            this.Name = obj.Name;
            this.ProductTypeTVAs = obj.ProductTypeTVAs;
            this.Products = obj.products;
        }
        #endregion
    }
}