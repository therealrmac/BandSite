using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class ThreadPost
    {
        [Key]
        public int ThreadPostId { get; set; }

        [Required]
        public string message { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
