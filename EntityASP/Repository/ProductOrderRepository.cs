using System;
using System.Collections.Generic;
using System.Linq;
using EntityASP.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Repository
    {
    public class ProductOrderRepository: Repository<ProductOrder>
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
        public ProductOrderRepository()
            {
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public float PercentageTVA(ProductOrder productOrder)
            {
            foreach (ProductTypeTVA item in productOrder.Product.ProductType.ProductTypeTVAs)
                if (item.TVA.EndDate == null)
                    return item.TVA.Rate;
            return 0;
            }

        public double PriceTVA(ProductOrder productOrder)
            {
            return productOrder.Product.ProductType.Price * productOrder.Quantity * this.PercentageTVA(productOrder) / 100;
            }

        public double PriceHT(ProductOrder productOrder)
            {
            return productOrder.Product.ProductType.Price * productOrder.Quantity;
            }

        public double PriceTTC(ProductOrder productOrder)
            {
            return this.PriceHT(productOrder) + this.PriceTVA(productOrder);
            }
        #endregion

        #region Events
        #endregion
        }
    }
