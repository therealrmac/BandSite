using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandSite.Models.ViewModels
{
    public class ThreadPostViewModel
    {
        public List<ThreadPost> threadpost { get; set; }
        public Forum Forum { get; set; }
    }
}
