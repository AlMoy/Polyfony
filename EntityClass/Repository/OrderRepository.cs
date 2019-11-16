﻿using System;
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
        public double PercentageTVA(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double percentage = 0;

            foreach (ProductOrder item in order.ProductOrders)
                percentage += productOrderRepository.PercentageTVA(item);

            return percentage / order.ProductOrders.Count;
            }

        public double PriceTVA(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double price = 0;
            
            foreach (ProductOrder item in order.ProductOrders)
                price += productOrderRepository.PriceTVA(item);

            //return price;
            return this.PriceHT(order) * this.PercentageTVA(order)/100;
            }

        public double PriceHT(Order order)
            {
            ProductOrderRepository productOrderRepository = new ProductOrderRepository();
            double price = 0;

            foreach (ProductOrder item in order.ProductOrders)
                price += productOrderRepository.PriceHT(item);

            return price;
            }

        public double PriceTTC(Order order)
            {
            return this.PriceHT(order) +this.PriceTVA(order);
            }

        public double FinalPrice(Order order)
            {
            return this.PriceTTC(order) - order.Remise;
            }
        #endregion

        #region Events
        #endregion
    }
    }
