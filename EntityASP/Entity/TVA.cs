﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Entity
{
    public class TVA
    {
        #region Attributs
        private long id;
        private float rate;
        private DateTime? endDate;
        private List<ProductTypeTVA> productTypeTVAs;

        #endregion

        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tva_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("tva_endDate")]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        [Required]
        [Display(Name = "Taux de TVA")]
        [Column("tva_rate")]
        [Range(0, 100)]
        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public List<ProductTypeTVA> ProductTypeTVAs
        {
            get { return productTypeTVAs; }
            set { productTypeTVAs = value; }
        }
        #endregion

        #region Constructors
        public TVA()
        {
            this.productTypeTVAs = new List<ProductTypeTVA>();
        }
        #endregion
    }
}