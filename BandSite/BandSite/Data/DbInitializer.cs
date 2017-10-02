using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandSite.Models;

namespace BandSite.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.ProductType.Any())
                {
                    return;
                }
                var productType = new ProductType[]
                {
                    new ProductType
                    {
                        CategoryName= "Shirts"
                    },
                    new ProductType
                    {
                        CategoryName= "Shoes"
                    },
                    new ProductType
                    {
                        CategoryName= "CD"
                    },
                    new ProductType
                    {
                        CategoryName= "Hoodies"
                    }
                };
                foreach (ProductType x in productType)
                {
                    context.ProductType.Add(x);
                }
                context.SaveChanges();



                var product = new Product[]
                {
                    new Product
                    {
                        Description= "Left To The Wolves all black shirt and logo",
                        Image= "",
                        Name="Shirt1",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 20
                    },
                    new Product
                    {
                        Description= "Left To The Wolves with unique design",
                        Image= "",
                        Name="Shirt2",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 15
                    },
                    new Product
                    {
                        Description= "Left To The Wolves murder lady",
                        Image= "",
                        Name="Shirt3",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 12
                    },
                    new Product
                    {
                        Description= "Left To The Wolves all white shirt and logo",
                        Image= "",
                        Name="Shirt4",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 20
                    },
                    new Product
                    {
                        Description="Left To The Wolves album",
                        Image= "",
                        Name= "CD1",
                        Price= 10.99,
                        ProductTypeID= 19,
                        Quantity= 50
                    },
                    new Product
                    {
                        Description= "Left To The Wolves album",
                        Image= "",
                        Name= "CD2",
                        Price= 9.99,
                        ProductTypeID= 19,
                        Quantity=25
                    },
                    new Product
                    {
                        Description= "Left To The Wolves album",
                        Image= "",
                        Name="CD3",
                        Price= 10.99,
                        ProductTypeID= 19,
                        Quantity= 30
                    }
                };
                foreach (Product x in product)
                {
                    context.Product.Add(x);
                }
                context.SaveChanges();


                var members = new Members[]
                {
                    new Members
                    {
                        Name= "Andy Yates",
                        Bio= "",
                        Facebook= "",
                        Twitter= ""
                    },
                    new Members
                    {
                        Name ="Danny",
                        Bio= "",
                        Facebook= "",
                        Twitter=""
                    },
                    new Members
                    {
                        Name= "Jordan",
                        Bio= "",
                        Facebook= "",
                        Twitter= ""
                    },
                    new Members
                    {
                        Name= "Anthony Scott",
                        Bio= "",
                        Facebook= "",
                        Twitter= ""
                    },
                    new Members
                    {
                        Name= "Chris Ryan",
                        Bio= "",
                        Facebook= "",
                        Twitter= "",
                    },
                    new Members
                    {
                        Name= "Preston Soper",
                        Bio= "",
                        Facebook= "",
                        Twitter= ""
                    }
                };
                foreach(Members x in members)
                {
                    context.Members.Add(x);
                }
                context.SaveChanges();
            }
        }
    }
}
