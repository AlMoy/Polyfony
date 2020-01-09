using System;
using System.Collections.Generic;
using EntityASP.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Repository
    {
    public class PersonRepository: Repository<Person>
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
        public PersonRepository(AppDbContext context) : base(context)
            {
            this.dbSet = context.PersonDb;
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
