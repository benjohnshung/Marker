using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public class Module
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IList<ContentItem>? Content { get; set; }
    }
}
