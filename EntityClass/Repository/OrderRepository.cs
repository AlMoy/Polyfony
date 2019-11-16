using System;
using EntityClass.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Repository
    {
    public class OrderRepository : Repository<Order>
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
        public OrderRepository()
            {
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public double percentageTVA(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double percentage = 0;

            foreach (ProductOrder item in order.ProductOrders)
                percentage += productOrderRepository.percentageTVA(item);

            return percentage / order.ProductOrders.Count;
            }

        public double priceTVA(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double price = 0;
            
            foreach (ProductOrder item in order.ProductOrders)
                price += productOrderRepository.priceTVA(item);

            //return price;
            return this.priceHT(order) * this.percentageTVA(order)/100;
            }

        public double priceHT(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double price = 0;

            foreach (ProductOrder item in order.ProductOrders)
                price += productOrderRepository.priceHT(item);

            return price;
            }

        public double priceTTC(Order order)
            {
            return this.priceHT(order) +this.priceTVA(order);
            }

        public double finalPrice(Order order)
            {
            return this.priceTTC(order) - order.Remise;
            }
        #endregion

        #region Events
        #endregion
    }
    }
