using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Repository
    {
    public abstract class Repository <T>
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
        public Repository()
            {
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public T Find(long id)
            {
            T item=default; 
            
            return item;
            }

        public List<T> FindAll()
            {
            List<T> items = new List<T>();

            return items;
            }

        public void Remove (long id)
            {
            
            }

        public T Create(T item)
            {
            T result = default;
            
            return result;
            }

        public T Update(long id, T item)
            {
            T result = default;
            
            return result;
            }
        #endregion
        }
    }
