
﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class ProductTypeTVA : EntityBase<ProductTypeTVA>
    {
        #region Attributs
        private long id;
        private long productTypeId;
        private long tvaId;
        private ProductType productType;
        private TVA tva;
      
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        public long Id
        {
            get { return id; }
            set { id = value; }
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

        [ForeignKey(typeof(TVA))]
        public long TvaId
        {
            get { return tvaId; }
            set { tvaId = value; }
        }

        [ManyToOne("TvaId")]
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
            productTypeTVA.ProductTypeId = this.ProductTypeId;
            productTypeTVA.TvaId = this.TvaId;
            productTypeTVA.ProductType = this.ProductType;
            productTypeTVA.TVA = this.TVA;

            return productTypeTVA;
            }

        public override void CopyFrom(ProductTypeTVA obj)
            {
            this.Id = obj.Id;
            this.ProductTypeId = obj.ProductTypeId;
            this.TvaId = obj.TvaId;
            this.ProductType = obj.ProductType;
            this.TVA = obj.TVA;
            }
        #endregion
        }
    }
