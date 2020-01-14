using System;
using System.Collections.Generic;
using EntityASP.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Repository
    {
    public class StateProductRepository: Repository<StateProduct>
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
        public StateProductRepository(AppDbContext context) : base(context)
            {
            this.dbSet = context.StateProductDb;
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
