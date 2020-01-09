using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
    {
    public class ProductOrder
        {
        #region Attributs
        private long id;
        private ulong quantity;
        private Product product;
        private Order order;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("po_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

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
