using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class BillingAddress
    {
        [Key]
        public int billingAddressId { get; set; }

        [Required]
        public string street { get; set; }

        public int? unitNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required(ErrorMessage = "Valid Zip is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public int ZipCode { get; set; }

        public bool isDefault { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        public virtual ICollection<Order> Order { get; set; }


    }
}
