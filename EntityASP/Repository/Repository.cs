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
        DbSet dbSet;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public Repository()
            {
            if(typeof(T) == typeof(Order))
                this.dbSet = new AppDbContext().OrderDb;

            if (typeof(T) == typeof(Person))
                this.dbSet = new AppDbContext().PersonDb;

            if (typeof(T) == typeof(Product))
                this.dbSet = new AppDbContext().ProductDb;

            if (typeof(T) == typeof(ProductOrder))
                this.dbSet = new AppDbContext().ProductOrdersDb;

            if (typeof(T) == typeof(ProductType))
                this.dbSet = new AppDbContext().ProductTypeDb;

            if (typeof(T) == typeof(Role))
                this.dbSet = new AppDbContext().RoleDb;

            if (typeof(T) == typeof(StateProduct))
                this.dbSet = new AppDbContext().StateProductDb;

            if (typeof(T) == typeof(TVA))
                this.dbSet = new AppDbContext().TvaDb;
            }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public async Task<T> FindAsync(long id)
            {
            return (T)await this.dbSet.FindAsync(id);
            }

        public async Task<List<T>> FindAllAsync()
            {
            return ((IList<T>)await this.dbSet.ToListAsync()).ToList();
            }

        public async Task<List<T>> FindByAsync(Dictionary<String, String> criteria, Dictionary<String, String> orderBy = null, ulong? limit = null, ulong? offset = null)
            {
            List<T> items = ((IList<T>)await this.dbSet.ToListAsync()).ToList();



            return items;
            }

        public void Remove(T item)
            {
            this.dbSet.Remove(item);
            }

        public T Create(T item)
            {
            return (T)this.dbSet.Add(item);
            }

        public T Update(ulong id, T item)
            {
            T result = default;
            this.dbSet.
            return result;
            }
        #endregion
        }
    }
