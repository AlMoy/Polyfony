using EntityASP;
using EntityASP.Entity;
using EntityASP.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
    {
    class Program
        {
        static async Task Main(string[] args)
            {
            using(AppDbContext context=new AppDbContext())
                {
                context.Initialize(true);
                List<Product> products = await new ProductRepository(context).FindAllAsync();
                foreach (Product product in products)
                    Console.WriteLine(product.Name);
                }
            Console.WriteLine("Fin du programme.");
            Console.ReadLine();
            }
        }
    }
