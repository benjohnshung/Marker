using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public class ContentItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }

        public override string ToString()
        {
            return $"Item: {Name} - {Description}";
        }
    }
}
