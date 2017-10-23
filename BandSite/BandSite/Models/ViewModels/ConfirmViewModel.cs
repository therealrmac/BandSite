using BandSite.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models.ViewModels
{
    public class ConfirmViewModel
    {
        public Order Order { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        [Display(Name = "Order Count")]
        public int OrderCount { get; set; }

        public Dictionary<Product, int> ProdCount = new Dictionary<Product, int>();

        public List<PaymentType> PayMethods = new List<PaymentType>();

        public List<ShippingAddress> Addresses = new List<ShippingAddress>();

        public ConfirmViewModel(ApplicationDbContext ctx, ApplicationUser user)
        {
            if (user != null)
            {
                var orderID = ctx.Order.Where(o => o.user.Email == user.Email && o.PaymentType == null).Select(p => p.OrderId).SingleOrDefault();
                if (user != null && orderID != 0)
                {
                    var allProducts = ctx.Product.ToList();
                    var productOrders = ctx.OrderProduct.Where(po => po.OrderId == orderID).ToList();

                    var Products = (from p in allProducts
                                    join po in productOrders on p.ProductId equals po.ProductId
                                    select p
                                           ).ToList();


                    ProdCount = Products.GroupBy(x => x)
                    .Where(g => g.Count() > 0)
                    .ToDictionary(x => x.Key, y => y.Count());

                    PayMethods = ctx.PaymentType.Where(p => p.user.Email == user.Email).ToList();
                    Addresses = ctx.ShippingAddress.Where(a => a.User.Email == user.Email).ToList();

                    OrderTotal = ctx.OrderProduct.Where(v => v.OrderId == orderID).Sum(p => p.Product.Price);
                    OrderCount = ctx.OrderProduct.Where(c => c.OrderId == orderID).Count();
                }
            }
        }
    }
}
