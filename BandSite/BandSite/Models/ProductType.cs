using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }


        [Required]
        [StringLength(25, ErrorMessage = "Product Name can not be more than 25 characters")]
        [Display(Name = "Product Category")]
        public string CategoryName { get; set; }
    }
}
