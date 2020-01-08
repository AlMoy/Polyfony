﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
    {
    public class ProductTypeTVA
        {
        #region Attributs
        private long id;
        private ProductType productType;
        private TVA tva;
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
        public ProductType ProductType
            {
            get { return productType; }
            set { productType = value; }
            }

        [Required]
        public TVA TVA
            {
            get { return tva; }
            set { tva = value; }
            }
        #endregion
        }
    }