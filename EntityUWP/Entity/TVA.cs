using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP.Entity
{
    public class TVA : EntityBase<TVA>
        {
        #region Attributs
        private long id;
        private float rate;
        private DateTime endDate;
        private List<ProductTypeTVA> productTypeTVAs;
        #endregion

        #region Properties
        [PrimaryKey, AutoIncrement]
        [Column("tva_id")]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

      
        [Column("tva_endDate")]
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        [NotNull]
        [Column("tva_rate")]
        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        [Ignore]
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

        #region Functions
        public override TVA Copy()
        {
            TVA tva = new TVA();
            tva.Id = this.Id;
            tva.Rate = this.Rate;
            tva.EndDate = this.EndDate;
            tva.ProductTypeTVAs = this.ProductTypeTVAs;

            return tva;
        }

        public override void CopyFrom(TVA obj)
        {
            this.Id = obj.Id;
            this.Rate = obj.Rate;
            this.EndDate = obj.EndDate;
            this.ProductTypeTVAs = obj.ProductTypeTVAs;
        }
        #endregion
    }
}
