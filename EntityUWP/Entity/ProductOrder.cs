﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
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
        [NotNull]
        [Column("po_quantity")]
        public ulong Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }

        [OneToMany("ProductId")]
        [NotNull]
        [Column("po_product")]
        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
        }

        private int productId;

        [ForeignKey(typeof(Product))]
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        [OneToMany("OrderId")]
        [NotNull]
        [Column("po_order")]
        public Order Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged("Order"); }
        }

        private int orderId;

        [ForeignKey(typeof(Order))]
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
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