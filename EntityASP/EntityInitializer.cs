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
        public static void Initialize(this AppDbContext context)
            {
            if (context.PersonDb.Any())
                return;
            
            List<Role> roles = new List<Role>()
                {
                new Role()
                    {
                    Name="Admin"
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

            List<Person> people = new List<Person>()
                {
                new Person()
                    {
                    LastName = "Moysan",
                    FirstName = "Alex",
                    Login = "admin",
                    PassWord = "Admin!123",
                    Address = "addr",
                    Mail ="admin@mail.com",
                    TelephoneNumber = "0128846868",
                    BirthDate = DateTime.Now
                    },
                new Person()
                    {
                    LastName = "Yattara",
                    FirstName = "Yaccouba",
                    Login = "vendeurYY",
                    PassWord = "Vendeur!123",
                    Address = "addr",
                    Mail ="yy@mail.com",
                    TelephoneNumber = "0128846868",
                    BirthDate = DateTime.Now
                    },
                new Person()
                    {
                    LastName = "Luu",
                    FirstName = "Trang",
                    Login = "vendeurTL",
                    PassWord = "Vendeur!123",
                    Address = "addr",
                    Mail ="tl@mail.com",
                    TelephoneNumber = "0128846868",
                    BirthDate = DateTime.Now
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

            List<TVA> tvas = new List<TVA>()
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
                    },
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
                    },
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
                    Name = "Trot-Enfant"
                    },
                new ProductType()
                    {
                    Price = 15.3F,
                    Name = "Trot-Femme",
                    },
                new ProductType()
                    {
                    Price = 18.8F,
                    Name = "Trot-Homme",
                    }
                };

            List<ProductTypeTVA> productTypeTVAs = new List<ProductTypeTVA>()
                {
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[0],
                    TVA = tvas[0]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[0],
                    TVA = tvas[1]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[0],
                    TVA = tvas[2]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[1],
                    TVA = tvas[3]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[1],
                    TVA = tvas[4]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[1],
                    TVA = tvas[5]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[2],
                    TVA = tvas[6]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[2],
                    TVA = tvas[7]
                    },
                new ProductTypeTVA()
                    {
                    ProductType = productTypes[2],
                    TVA = tvas[8]
                    }
                };

            List<Product> products = new List<Product>()
                {
                new Product()
                    {
                    Size = "S",
                    Name = "Trot-Elect",
                    Weight = 2.1F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "M",
                    Name = "Trot-Elect",
                    Weight = 4.0F,
                    Color = "Noir",
                    Quantity = 25,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "L",
                    Name = "Trot-Elect",
                    Weight = 5.2F,
                    Color = "Noir",
                    Quantity = 42,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "M",
                    Name = "Trot-Simple",
                    Weight = 1.8F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "S",
                    Name = "Trot-Simple",
                    Weight = 3.8F,
                    Color = "Noir",
                    Quantity = 25,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "M",
                    Name = "Trot-Simple",
                    Weight = 5.3F,
                    Color = "Noir",
                    Quantity = 42,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "L",
                    Name = "Trot-Elect",
                    Weight = 2.2F,
                    Color = "Blanc",
                    Quantity = 10,
                    ToValid = true,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "S",
                    Name = "Trot-Elect",
                    Weight = 2.5F,
                    Color = "Blanc",
                    Quantity = 40,
                    ToValid = false,
                    ProductType = productTypes[1]
                    },
                new Product()
                    {
                    Size = "M",
                    Name = "Trot-Simple",
                    Weight = 3.6F,
                    Color = "Rouge",
                    Quantity = 25,
                    ToValid = false,
                    ProductType = productTypes[0]
                    },
                new Product()
                    {
                    Size = "S",
                    Name = "Trot-Elect",
                    Weight = 1.5F,
                    Color = "Noir",
                    Quantity = 30,
                    ToValid = false,
                    ProductType = productTypes[2]
                    },
                new Product()
                    {
                    Size = "L",
                    Name = "Trot-Elect",
                    Weight = 1.5F,
                    Color = "Marron",
                    Quantity = 15,
                    ToValid = false,
                    ProductType = productTypes[1]
                    },
                new Product()
                    {
                    Size = "S",
                    Name = "Trot-Simple",
                    Weight = 1.7F,
                    Color = "Bleu",
                    Quantity = 15,
                    ToValid = false,
                    ProductType = productTypes[0]
                    }
                };

            List<ProductStateProduct> productStateProducts = new List<ProductStateProduct>()
                {
                new ProductStateProduct()
                    {
                    Product = products[0],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[1],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[2],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[3],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[4],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[5],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[6],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[7],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[8],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[9],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[10],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[11],
                    StateProduct = stateProducts[0]
                    },
                new ProductStateProduct()
                    {
                    Product = products[0],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[1],
                    StateProduct = stateProducts[2]
                    },
                new ProductStateProduct()
                    {
                    Product = products[2],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[3],
                    StateProduct = stateProducts[2]
                    },
                new ProductStateProduct()
                    {
                    Product = products[4],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[5],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[6],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[7],
                    StateProduct = stateProducts[2]
                    },
                new ProductStateProduct()
                    {
                    Product = products[8],
                    StateProduct = stateProducts[1]
                    },
                new ProductStateProduct()
                    {
                    Product = products[9],
                    StateProduct = stateProducts[2]
                    },
                new ProductStateProduct()
                    {
                    Product = products[10],
                    StateProduct = stateProducts[2]
                    },
                new ProductStateProduct()
                    {
                    Product = products[11],
                    StateProduct = stateProducts[1]
                    }
                };

            context.RoleDb.AddRange(roles);
            context.StateProductDb.AddRange(stateProducts);
            context.TvaDb.AddRange(tvas);
            context.ProductTypeTvaDb.AddRange(productTypeTVAs);
            context.ProductTypeDb.AddRange(productTypes);
            context.ProductDb.AddRange(products);
            context.ProductStateProductDb.AddRange(productStateProducts);
            
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
