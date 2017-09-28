using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "This field can only have 16 digits")]
        [Display(Name = "Card Number")]
        public int cardInfo { get; set; }

        [Required]
        [StringLength(3, ErrorMessage ="This field can only have 3 digits")]
        [Display(Name ="3 Digit Code")]
        public int threeDigit { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        public bool? isActive { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
