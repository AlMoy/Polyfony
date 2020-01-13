using EntityUWP.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityUWP
{
    public class AppDbContext : DbContext
    {
        #region Property
        public DbSet<Order> OrderDb { get; set; }
        public DbSet<Person> PersonDb { get; set; }
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<ProductOrder> ProductOrdersDb { get; set; }
        public DbSet<ProductType> ProductTypeDb { get; set; }
        public DbSet<Role> RoleDb { get; set; }
        public DbSet<StateProduct> StateProductDb { get; set; }
        public DbSet<TVA> TvaDb { get; set; }
        #endregion

        #region Constructors
        public AppDbContext() : base()
        {
        }
        #endregion

        #region function
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #endregion
        }
    }


