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
            {//Relation Many-To-Many => TVA -To- ProductType
            modelBuilder.Entity<ProductTypeTVA>().HasOne<TVA>(ptt => ptt.TVA).WithMany(t => t.ProductTypeTVAs);

            modelBuilder.Entity<ProductTypeTVA>().HasOne<ProductType>(ptt => ptt.ProductType).WithMany(t => t.ProductTypeTVAs);
            //Relation One-To-Many => ProductType -To- Product
            modelBuilder.Entity<Product>().HasOne<ProductType>(p => p.ProductType).WithMany(pt => pt.Products);
            //Relation Many-To-Many => Product -To- StateProduct
            modelBuilder.Entity<ProductStateProduct>().HasOne<Product>(psp => psp.Product).WithMany(p => p.ProductStateProducts);
            modelBuilder.Entity<ProductStateProduct>().HasOne<StateProduct>(psp => psp.StateProduct).WithMany(sp => sp.ProductStateProducts);
            //Relation Many-To-Many =>  Product -To- Order
            modelBuilder.Entity<ProductOrder>().HasOne<Product>(po => po.Product).WithMany(p => p.ProductOrders);
            modelBuilder.Entity<ProductOrder>().HasOne<Order>(po => po.Order).WithMany(o => o.ProductOrders);
            //Relation Many-To-One => Order -To- Person
            modelBuilder.Entity<Person>().HasMany<Order>(p => p.Orders).WithOne(o => o.Client);
            //Relation Many-To-One => Order -To- Person
            modelBuilder.Entity<Person>().HasMany<Order>(p => p.Orders).WithOne(o => o.Seller);
            //Relation One-To-Many => Role -To- Person
            modelBuilder.Entity<Person>().HasOne<Role>(p => p.Role).WithMany(r => r.People);

            modelBuilder.Entity<Person>().HasIndex(p => p.Login).IsUnique();

            base.OnModelCreating(modelBuilder);
            }
        #endregion
        }
    }
