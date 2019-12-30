using EntityASP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityASP
    {
    public static class EntityInitializer
        {
        public static void Initialize(this AppDbContext context, bool dropAlways = false)
            {
            //To drop database or not
            if (dropAlways && context.Database.Exists())
                context.Database.Delete();

            context.Database.CreateIfNotExists();

            //if db has been already seeded
            if (context.PersonDb.Any())
                return;

            List<Role> roles = new List<Role>()
                {
                new Role()
                    {
                    Name="Administrateur"
                    },
                new Role()
                    {
                    Name="Vendeur"
                    },
                new Role()
                    {
                    Name="Client"
                    }
                };

            List<Person> peoples = new List<Person>()
                {
                new Person()
                    {
                    LastName = "Moysan",
                    FirstName = "Alex",
                    Address = "addr",
                    Mail = "alex.moysan@mail.com",
                    TelephoneNumber = "0761006692",
                    BirthDate = DateTime.Now,
                    Login = "alex",
                    PassWord = "password",
                    Role = roles[0],
                    },
                new Person()
                    {
                    LastName = "Luu",
                    FirstName = "Trang",
                    Address = "addr",
                    Mail = "trang.luu@mail.com",
                    TelephoneNumber = "0761006692",
                    BirthDate = DateTime.Now,
                    Login = "trang",
                    PassWord = "password",
                    Role = roles[1],
                    },
                new Person()
                    {
                    LastName = "Yacaba",
                    FirstName = "Yacouba",
                    Address = "addr",
                    Mail = "yacouba.yacaba@mail.com",
                    TelephoneNumber = "0761006692",
                    BirthDate = DateTime.Now,
                    Login = "yacouba",
                    PassWord = "password",
                    Role = roles[1],
                    },
                new Person()
                    {
                    LastName = "Foursov",
                    FirstName = "Fatumata",
                    Address = "addr",
                    Mail = "fatumata.foursov@mail.com",
                    TelephoneNumber = "0761006692",
                    BirthDate = DateTime.Now,
                    Login = "fatumata",
                    PassWord = "password",
                    Role = roles[2],
                    }
                };

            List<StateProduct> stateProducts = new List<StateProduct>()
                {
                new StateProduct()
                    {
                    Name = "Livrable"
                    },
                new StateProduct()
                    {
                    Name = "Assurance"
                    },
                new StateProduct()
                    {
                    Name = "Echange"
                    }
                };

            List<TVA> tvas1 = new List<TVA>()
                {
                new TVA()
                    {
                    Rate = 2.5F,
                    EndDate = DateTime.Parse("12/01/2019")
                    },
                new TVA()
                    {
                    Rate = 12.3F,
                    EndDate = DateTime.Parse("12/03/2019")
                    },
                new TVA()
                    {
                    Rate = 5.7F,
                    EndDate = null
                    }
                };

            List<TVA> tvas2 = new List<TVA>()
                {
                new TVA()
                    {
                    Rate = 7.2F,
                    EndDate = DateTime.Parse("12/05/2019")
                    },
                new TVA()
                    {
                    Rate = 23.4F,
                    EndDate = DateTime.Parse("12/07/2019")
                    },
                new TVA()
                    {
                    Rate = 1.9F,
                    EndDate = null
                    }
                };

            List<TVA> tvas3 = new List<TVA>()
                {
                new TVA()
                    {
                    Rate = 15.0F,
                    EndDate = DateTime.Parse("12/02/2019")
                    },
                new TVA()
                    {
                    Rate = 5.6F,
                    EndDate = DateTime.Parse("12/06/2019")
                    },
                new TVA()
                    {
                    Rate = 3.1F,
                    EndDate = null
                    }
                };

            List<ProductType> productTypes = new List<ProductType>()
                {
                new ProductType()
                    {
                    Price = 20.5F,
                    Name = "Trot-Enfant",
                    TVAS = tvas1
                    },
                new ProductType()
                    {
                    Price = 15.3F,
                    Name = "Trot-Femme",
                    TVAS = tvas2
                    },
                new ProductType()
                    {
                    Price = 18.8F,
                    Name = "Trot-Homme",
                    TVAS = tvas3
                    }
                };

            List<Product> products = new List<Product>()
                {
                new Product()
                    {
                    Size = 0.2F,
                    Name = "Trot-Elect",
                    Weight = 2.1F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.5F,
                    Name = "Trot-Elect",
                    Weight = 4.0F,
                    Color = "Noir",
                    Quantity = 25,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.7F,
                    Name = "Trot-Elect",
                    Weight = 5.2F,
                    Color = "Noir",
                    Quantity = 42,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.2F,
                    Name = "Trot-Simple",
                    Weight = 1.8F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.5F,
                    Name = "Trot-Simple",
                    Weight = 3.8F,
                    Color = "Noir",
                    Quantity = 25,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.7F,
                    Name = "Trot-Simple",
                    Weight = 5.3F,
                    Color = "Noir",
                    Quantity = 42,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.2F,
                    Name = "Trot-Elect",
                    Weight = 2.2F,
                    Color = "Blanc",
                    Quantity = 10,
                    ToValid = true,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.2F,
                    Name = "Trot-Elect",
                    Weight = 2.5F,
                    Color = "Blanc",
                    Quantity = 40,
                    ToValid = false,
                    StateProducts = stateProducts,
                    ProductType = productTypes[1]
                    },
                new Product()
                    {
                    Size = 0.5F,
                    Name = "Trot-Simple",
                    Weight = 3.6F,
                    Color = "Rouge",
                    Quantity = 25,
                    ToValid = false,
                    StateProducts = stateProducts,
                    ProductType = productTypes[0]
                    },
                new Product()
                    {
                    Size = 0.2F,
                    Name = "Trot-Elect",
                    Weight = 1.5F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = false,
                    StateProducts = stateProducts,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = 0.5F,
                    Name = "Trot-Elect",
                    Weight = 1.5F,
                    Color = "Marron",
                    Quantity = 15,
                    ToValid = false,
                    StateProducts = stateProducts,
                    ProductType = productTypes[1]
                    },
                new Product()
                    {
                    Size = 0.8F,
                    Name = "Trot-Simple",
                    Weight = 1.7F,
                    Color = "Bleu",
                    Quantity = 15,
                    ToValid = false,
                    StateProducts = stateProducts,
                    ProductType = productTypes[0]
                    }
                };

            context.RoleDb.AddRange(roles);
            context.PersonDb.AddRange(peoples);
            context.StateProductDb.AddRange(stateProducts);
            context.TvaDb.AddRange(tvas1);
            context.TvaDb.AddRange(tvas2);
            context.TvaDb.AddRange(tvas3);
            context.ProductTypeDb.AddRange(productTypes);
            context.ProductDb.AddRange(products);

            //If a problem for save the test datas
            try
                {
                context.SaveChanges();
                }
            catch (Exception e)
                {
                Console.WriteLine(e.Message);
                //Print the errors of datas for entitys (annotations => "required",...)
                foreach (var gve in context.GetValidationErrors())
                    foreach (var ve in gve.ValidationErrors)
                        Console.WriteLine(new StringBuilder("\n-------------------")
                            .Append("\nErrorMessage: ")
                            .Append(ve.ErrorMessage)
                            .Append("\nGetHashCode: ")
                            .Append(ve.GetHashCode())
                            .Append("\nGetType: ")
                            .Append(ve.GetType())
                            .Append("\nPropertyName: ")
                            .Append(ve.PropertyName));
                }
            }
        }
    }
