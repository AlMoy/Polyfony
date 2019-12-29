using EntityASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
    {
    class Program
        {
        static void Main(string[] args)
            {
            using(AppDbContext context=new AppDbContext())
                {
                context.Initialize(false);
                }
            Console.WriteLine("Fin du programme.");
            Console.ReadLine();
            }
        }
    }
