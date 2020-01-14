using EntityUWP.Entity;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWP_SellIt.Services
{
    public class DatabaseService
    {
        private SQLiteConnection sqliteConnection;

        public SQLiteConnection SqliteConnection
        {
            get { return sqliteConnection; }
            set { sqliteConnection = value; }
        }

        public TableQuery<Role> Roles
        {
            get { return this.sqliteConnection.Table<Role>(); }
        }

        public TableQuery<Person> People
        {
            get { return this.sqliteConnection.Table<Person>(); }
        }

        public TableQuery<TVA> TVAs
        {
            get { return this.sqliteConnection.Table<TVA>(); }
        }

        public TableQuery<ProductType> ProductTypes
        {
            get { return this.sqliteConnection.Table<ProductType>(); }
        }

        public TableQuery<Product> Products
        {
            get { return this.sqliteConnection.Table<Product>(); }
        }

        public TableQuery<Order> Orders
        {
            get { return this.sqliteConnection.Table<Order>(); }
        }

        public TableQuery<OrderPerson> OrderPersons
        {
            get { return this.sqliteConnection.Table<OrderPerson>(); }
        }


        public TableQuery<ProductTypeTVA> ProductTypeTVAs
        {
            get { return this.sqliteConnection.Table<ProductTypeTVA>(); }
        }

        public TableQuery<StateProduct> StateProducts
        {
            get { return this.sqliteConnection.Table<StateProduct>(); }
        }

        public TableQuery<ProductStateProduct> ProductStateProducts
        {
            get { return this.sqliteConnection.Table<ProductStateProduct>(); }
        }

        public TableQuery<ProductOrder> ProductOrders
        {
            get { return this.sqliteConnection.Table<ProductOrder>(); }
        }


        public List<Role> RolesEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Role>(); }
        }

        public List<Person> PeopleEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Person>(); }
        }

        public List<TVA> TVAsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<TVA>(); }
        }
        public List<ProductType> ProductTypesEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<ProductType>(); }
        }
        public List<Product> ProductsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Product>(); }
        }


        public List<Order> OrdersEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Order>(); }
        }
               
        public List<StateProduct> StateProductsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<StateProduct>(); }
        }

        public List<OrderPerson> OrderPersonsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<OrderPerson>(); }
        }

        public List<ProductStateProduct> ProductStateProductsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<ProductStateProduct>(); }
        }

        public List<ProductOrder> ProductOrdersEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<ProductOrder>(); }
        }

        public List<ProductTypeTVA> ProductTypeTVAsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<ProductTypeTVA>(); }
        }

        public int Save(object item)
        {
            return this.sqliteConnection.InsertOrReplace(item);
        }

        public void SaveWithChildren(Person item)
        {
            this.Save(item.Role);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.OrderPerson);
            this.sqliteConnection.InsertOrReplaceWithChildren(item, true);
        }

        public void SaveWithChildren(Product item)
        {
            this.Save(item.ProductType);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.ProductOrders);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.ProductStateProducts);
            this.sqliteConnection.InsertOrReplaceWithChildren(item, true);
        }

        public void SaveWithChildren(ProductType item)
        {
            this.Save(item);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.ProductTypeTVAs);            
            this.sqliteConnection.InsertOrReplaceWithChildren(item, true);
        }

        public void SaveWithChildren(Order item)
        {
            this.Save(item);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.OrderPerson);
            this.sqliteConnection.InsertOrReplaceWithChildren(item.ProductOrders);
            this.sqliteConnection.InsertOrReplaceWithChildren(item, true);
        }


        public DatabaseService()
        {
            AutoResetEvent eRF = new AutoResetEvent(false);
            Task.Factory.StartNew(async () =>
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile myDb = await localFolder.CreateFileAsync("mydb.sqlite",
                        CreationCollisionOption.OpenIfExists);
                this.sqliteConnection = new SQLiteConnection(myDb.Path, SQLiteOpenFlags.ReadWrite);
                Task.Delay(TimeSpan.FromMilliseconds(50)).Wait();
                while (this.sqliteConnection == null)
                {
                    Task.Delay(TimeSpan.FromMilliseconds(50)).Wait();
                }
                this.sqliteConnection.CreateTable<Role>();
                this.sqliteConnection.CreateTable<Person>();               
                this.sqliteConnection.CreateTable<TVA>();
                this.sqliteConnection.CreateTable<ProductType>();
                this.sqliteConnection.CreateTable<ProductTypeTVA>();
                this.sqliteConnection.CreateTable<StateProduct>();
                this.sqliteConnection.CreateTable<ProductStateProduct>();
                this.sqliteConnection.CreateTable<Order>();
                this.sqliteConnection.CreateTable<OrderPerson>();               
                this.sqliteConnection.CreateTable<Product>();
                this.sqliteConnection.CreateTable<ProductOrder>();
                                          
              
                eRF.Set();
            });
            eRF.WaitOne();

        }
    }
}
