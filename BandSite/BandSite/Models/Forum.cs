using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models
{
    public class Forum
    {
        [Key]
        public int ForumId { get; set; }

        [Required]
        public ApplicationUser user { get; set; }

        [Required]
        public string ForumTitle { get; set; }

        [Required]
        public string ForumMessage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public ICollection<ThreadPost> ThreadPost {get;set;}
    }
}
