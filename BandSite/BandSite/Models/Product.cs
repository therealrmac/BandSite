using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Product Name can not be more than 25 charachters")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }

        public string Image { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Description can not be more than 155 charachters")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int ProductTypeID { get; set; }
        public ProductType ProductTypes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        

        public ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
