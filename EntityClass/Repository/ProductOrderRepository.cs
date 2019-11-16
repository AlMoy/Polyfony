using System;
using System.Collections.Generic;
using System.Linq;
using EntityClass.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Repository
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
        public float percentageTVA(ProductOrder productOrder)
            {
            foreach (TVA item in productOrder.Product.ProductType.TVAS)
                if (item.EndDate == null)
                    return item.Rate;
            return 0;
            }

        public double priceTVA(ProductOrder productOrder)
            {
            return productOrder.Product.ProductType.Price * productOrder.Quantity * this.percentageTVA(productOrder) / 100;
            }

        public double priceHT(ProductOrder productOrder)
            {
            return productOrder.Product.ProductType.Price * productOrder.Quantity;
            }

        public double priceTTC(ProductOrder productOrder)
            {
            return this.priceHT(productOrder) + this.priceTVA(productOrder);
            }
        #endregion

        #region Events
        #endregion
        }
    }
