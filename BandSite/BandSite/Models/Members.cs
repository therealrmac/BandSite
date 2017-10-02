using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Bio { get; set; }

        [Required]
        public string Facebook { get; set; }

        [Required]
        public string Twitter { get; set; }


    }
}
