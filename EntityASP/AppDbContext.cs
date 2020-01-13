using EntityASP.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP
    {
     public class AppDbContext : DbContext
        {
        #region Property
        public DbSet<Order> OrderDb { get; set; }
        public DbSet<Person> PersonDb { get; set; }
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<ProductOrder> ProductOrderDb { get; set; }
        public DbSet<ProductStateProduct> ProductStateProductDb { get; set; }
        public DbSet<ProductType> ProductTypeDb { get; set; }
        public DbSet<ProductTypeTVA> ProductTypeTvaDb { get; set; }
        public DbSet<Role> RoleDb { get; set; }
        public DbSet<StateProduct> StateProductDb { get; set; }
        public DbSet<TVA> TvaDb { get; set; }
        #endregion

        #region Constructors
        public AppDbContext() : base()
            {
            }
        #endregion

        #region Function
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {//Relation Many-To-Many => TVA -To- ProductType
            modelBuilder.Entity<ProductTypeTVA>().HasRequired<TVA>(ptt => ptt.TVA).WithMany(t => t.ProductTypeTVAs);
            modelBuilder.Entity<ProductTypeTVA>().HasRequired<ProductType>(ptt => ptt.ProductType).WithMany(t => t.ProductTypeTVAs);
            //Relation One-To-Many => ProductType -To- Product
            modelBuilder.Entity<Product>().HasRequired<ProductType>(p => p.ProductType).WithMany(pt => pt.Products);
            //Relation Many-To-Many => Product -To- StateProduct
            modelBuilder.Entity<ProductStateProduct>().HasRequired<Product>(psp => psp.Product).WithMany(p => p.ProductStateProducts);
            modelBuilder.Entity<ProductStateProduct>().HasRequired<StateProduct>(psp => psp.StateProduct).WithMany(sp => sp.ProductStateProducts);
            //Relation Many-To-Many => Product -To- Order
            modelBuilder.Entity<ProductOrder>().HasRequired<Product>(po => po.Product).WithMany(p => p.ProductOrders);
            modelBuilder.Entity<ProductOrder>().HasRequired<Order>(po => po.Order).WithMany(o => o.ProductOrders);
            //Relation Many-To-Many => Order -To- Person
            modelBuilder.Entity<OrderPerson>().HasRequired<Order>(op => op.Order).WithMany(o => o.OrderPersons);
            modelBuilder.Entity<OrderPerson>().HasRequired<Person>(op => op.Person).WithMany(o => o.OrderPersons);
            //Relation One-To-Many => Role -To- Person
            modelBuilder.Entity<Person>().HasRequired<Role>(p => p.Role).WithMany(r => r.People);

            modelBuilder.Entity<Person>().HasIndex(p => p.Login).IsUnique();

            base.OnModelCreating(modelBuilder);
            }

        public bool CheckConnection()
            {
            try
                {
                this.Database.Connection.Open();
                this.Database.Connection.Close();
                }
            catch (SqlException)
                {
                return false;
                }
            return true;
            }
        #endregion
        }
    }
