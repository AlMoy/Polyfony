﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class ProductOrder : EntityBase<ProductOrder>
        {
        #region Attributs
        private ulong quantity;
        private Product product;
        private Order order;
        #endregion

        #region Properties
        [Required]
        [Column("po_quantity")]
        public ulong Quantity
            {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
            }

        [Required]
        [Column("po_product")]
        public Product Product
            {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
            }

        [Required]
        [Column("po_order")]
        public Order Order
            {
            get { return order; }
            set { order = value; OnPropertyChanged("Order"); }
            }
        #endregion

        #region Constructors
        public ProductOrder()
            {
            }
        #endregion

        #region Functions
        public override ProductOrder Copy()
            {
            ProductOrder productOrder = new ProductOrder();
            productOrder.Quantity = this.Quantity;
            productOrder.Product = this.Product;
            productOrder.Order = this.Order;

            return productOrder;
            }

        public override void CopyFrom(ProductOrder obj)
            {
            this.Quantity = obj.Quantity;
            this.Product = obj.Product;
            this.Order = obj.Order;
            }
        #endregion
        }
    }
