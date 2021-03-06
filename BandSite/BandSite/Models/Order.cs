﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }


        [Display(Name ="Payment Type")]
        public int? paymentType { get; set; }
        public PaymentType PaymentType { get; set; }

        [Display(Name ="Shipping Address")]
        public int? shippingAddress { get; set; }
        public ShippingAddress ShippingAddress{ get; set; }

        public ICollection<OrderProduct> OrderProduct { get; set; }


    }
}
