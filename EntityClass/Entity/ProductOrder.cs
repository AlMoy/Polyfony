﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Entity
    {
    public class ProductOrder
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
            set { quantity = value; }
            }

        [Required]
        [Column("po_product")]
        public Product Product
            {
            get { return product; }
            set { product = value; }
            }

        [Required]
        [Column("po_order")]
        public Order Order
            {
            get { return order; }
            set { order = value; }
            }
        #endregion

        #region Constructors
        public ProductOrder()
            {
            }
        #endregion
        }
    }
