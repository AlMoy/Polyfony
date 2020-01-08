using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
    {
    public class ProductStateProduct
        {
        #region Attributs
        private long id;
        private Product product;
        private StateProduct stateProduct;
        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
            {
            get { return id; }
            set { id = value; }
            }

        [Required]
        public Product Product
            {
            get { return product; }
            set { product = value; }
            }

        [Required]
        public StateProduct StateProduct
            {
            get { return stateProduct; }
            set { stateProduct = value; }
            }
        #endregion
        }
    }
