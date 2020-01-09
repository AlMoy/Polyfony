using EntityASP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP.Repository
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
        protected DbContext context;
        protected DbSet dbSet;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public Repository(DbContext context)
            {
            this.context = context;
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public async Task<T> FindAsync(long? id)
            {
            return (T)await this.dbSet.FindAsync(id);
            }

        public async Task<List<T>> FindAllAsync()
            {
            List<object> items = await this.dbSet.ToListAsync();
            List<T> ts = new List<T>();

            foreach (object item in items)
                ts.Add((T)item);

            return ts;
            }

        public async Task<List<T>> FindByAsync(Dictionary<String, String> criteria, Dictionary<String, String> orderBy = null, long? limit = null, long? offset = null)
            {
            List<T> items = ((IList<T>)await this.dbSet.ToListAsync()).ToList();

            
            return items;
            }

        public async Task Remove(T item)
            {
            this.dbSet.Remove(item);
            await this.context.SaveChangesAsync();
            }

        public async Task<T> CreateAsync(T item)
            {
            item=(T)this.dbSet.Add(item);
            await this.context.SaveChangesAsync();
            return item;
            }

        public async Task UpdateAsync(T item)
            {
            this.context.Entry(item).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            }
        #endregion
        }
    }
