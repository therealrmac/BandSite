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
                        Facebook= "https://www.facebook.com/andy.yates.c2c",
                        Twitter= "",
                        Image = "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/13895077_1342001795829237_1980520063897551604_n.jpg?oh=b4c049e5e5c6d45a93086199566855f9&oe=5A78FFF3"
                    },
                    new Members
                    {
                        Name ="Daniel Brown",
                        Bio= "",
                        Facebook= "https://www.facebook.com/daniel.brown.31924792",
                        Twitter="",
                        Image = "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/13902736_10209901331631635_81218155356043826_n.jpg?oh=f4bcb0b8f99aac2f6deea5347cd5e5db&oe=5A818CDB"
                    },
                    new Members
                    {
                        Name= "Jordan Fields",
                        Bio= "",
                        Facebook= "https://www.facebook.com/jordan.s.fields?lst=100000159441082%3A100000662620001%3A1507941260",
                        Twitter= "",
                        Image= "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/17103527_1500130823352324_8620897397958900742_n.jpg?oh=5aa79c1c299b876728ff43c0849c3270&oe=5A81D844"
                    },
                    new Members
                    {
                        Name= "Anthony Scott",
                        Bio= "",
                        Facebook= "https://www.facebook.com/profile.php?id=100001492597701",
                        Twitter= "",
                        Image= "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/21764924_1567218056671266_2216548639073722149_n.jpg?oh=01ae445350dabc18b922e7a44a1913eb&oe=5A6DE449"
                    },
                    new Members
                    {
                        Name= "Chris Obryan",
                        Bio= "",
                        Facebook= "https://www.facebook.com/chris.obryan.31",
                        Twitter= "",
                        Image= "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/12250159_10207257860661226_5729887630947880619_n.jpg?oh=91f549c2f088280898fd0da427c5b03f&oe=5A6CECC4"
                    },
                    new Members
                    {
                        Name= "Preston Soper",
                        Bio= "",
                        Facebook= "https://www.facebook.com/preston.soper.9",
                        Twitter= "",
                        Image= "https://scontent-ort2-1.xx.fbcdn.net/v/t1.0-9/15349560_211070119347919_689428087339021411_n.jpg?oh=42703699ff9935ece52f55362aee2c02&oe=5A7390B7"
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
