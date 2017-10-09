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
                        Image= "http://images.bigcartel.com/product_images/179538878/12007234_10208094762703254_549503210_n_%282%29.jpg?auto=format&fit=max&w=560",
                        Name="Shirt1",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 20
                    },
                    new Product
                    {
                        Description= "Left To The Wolves with unique design",
                        Image= "http://images.bigcartel.com/product_images/172798903/20160131_145912.jpg?auto=format&fit=max&w=560",
                        Name="Shirt2",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 15
                    },
                    new Product
                    {
                        Description= "Left To The Wolves murder lady",
                        Image= "http://images.bigcartel.com/product_images/172798885/20160131_150732.jpg?auto=format&fit=max&w=560",
                        Name="Shirt3",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 12
                    },
                    new Product
                    {
                        Description= "Left To The Wolves all white shirt and logo",
                        Image= "http://images.bigcartel.com/product_images/179538659/left_to_the_wolves-shiva-blue-shirt.jpg?auto=format&fit=max&w=560",
                        Name="Shirt4",
                        Price= 15.99,
                        ProductTypeID= 17,
                        Quantity= 20
                    },
                    new Product
                    {
                        Description="Left To The Wolves album",
                        Image= "http://images.bigcartel.com/product_images/88007558/Album_Cover.jpg?auto=format&fit=max&h=1000&w=1000",
                        Name= "CD1",
                        Price= 10.99,
                        ProductTypeID= 19,
                        Quantity= 50
                    },
                    new Product
                    {
                        Description= "Left To The Wolves album",
                        Image= "https://pbs.twimg.com/media/CYcKK4VWYAAQNck.jpg",
                        Name= "CD2",
                        Price= 9.99,
                        ProductTypeID= 19,
                        Quantity=25
                    },
                    new Product
                    {
                        Description= "Left To The Wolves album",
                        Image= "https://gp1.wac.edgecastcdn.net/802892/http_public_production/artists/images/1443095/original/hash:1467158494/1390065673_cabin_lttw.jpg?1467158494",
                        Name="CD3",
                        Price= 10.99,
                        ProductTypeID= 19,
                        Quantity= 30
                    },
                    new Product
                    {
                        Description= "Left to The Wolves hoody",
                        Image= "http://images.bigcartel.com/product_images/134915727/IMG_20140330_210856.jpg?auto=format&fit=max&h=1000&w=1000",
                        Name= "Hoody1",
                        Price= 25.00,
                        ProductTypeID= 20,
                        Quantity= 10
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
