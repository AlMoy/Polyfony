using System;
using System.Collections.Generic;
using System.Linq;
using EntityASP.Entity;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Repository
    {
    public class ProductRepository : Repository<Product>
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
        public ProductRepository(AppDbContext context) : base(context)
            {
            this.dbSet = context.ProductDb;
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
        }
    }
