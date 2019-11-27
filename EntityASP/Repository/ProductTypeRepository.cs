using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityASP.Entity;
using System.Threading.Tasks;

namespace EntityASP.Repository
    {
    public class ProductTypeRepository : Repository<ProductType>
        {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors 
        public ProductTypeRepository()
            {
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public ulong numberProductsStock(ulong id)
            {
            ulong numberStock = 0;
            ProductType productType = this.Find(id);
            //If id matche at a productType in database
            if(productType!=null)
                foreach (Product item in productType.Products)
                    if (item.Quantity > 0)
                        numberStock++;

            return numberStock;
            }
        public ulong numberProductsStock(ProductType productType)
            {
            ulong numberStock = 0;
            foreach (Product item in productType.Products)
                if(item.Quantity>0)
                    numberStock++;

            return numberStock;
            }

        public ulong quantityProductsStock(ulong id)
            {
            ulong quantityStock = 0;
            ProductType productType = this.Find(id);
            //If id matche at a productType in database
            if (productType != null)
                foreach (Product item in productType.Products)
                    quantityStock+=item.Quantity;

            return quantityStock;
            }

        public ulong quantityProductsStock(ProductType productType)
            {
            ulong quantityStock = 0;
            foreach (Product item in productType.Products)
                quantityStock += item.Quantity;

            return quantityStock;
            }
        #endregion

        #region Events
        #endregion
    }
    }
