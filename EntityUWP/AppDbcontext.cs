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
            {//Relation One-To-Many => ProductType -To- TVA 
            modelBuilder.Entity<TVA>().HasOne<ProductType>(t => t.ProductType).WithMany(pt => pt.TVAS);
            //Relation One-To-Many => ProductType -To- Product
            modelBuilder.Entity<Product>().HasOne<ProductType>(p => p.ProductType).WithMany(pt => pt.Products);
            //Relation Many-To-Many => StateProduct -To- Product
            //modelBuilder.Entity<StateProduct>().HasMany<Product>(sp => sp.Products).WithMany(p => p.StateProducts);
            //Relation One-To-Many => Product -To- ProductOrder
            modelBuilder.Entity<ProductOrder>().HasOne<Product>(po => po.Product).WithMany(p => p.ProductOrders);
            //Relation One-To-Many => Order -To- ProductOrder
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
