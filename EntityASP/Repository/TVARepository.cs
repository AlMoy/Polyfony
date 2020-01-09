using System;
using System.Collections.Generic;
using System.Linq;
using EntityASP.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityASP.Repository
    {
    public class TVARepository: Repository<TVA>
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
        public TVARepository(AppDbContext context) : base(context)
            {
            this.dbSet = context.TvaDb;
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
