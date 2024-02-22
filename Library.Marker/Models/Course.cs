using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public class Course
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IList<Person>? Roster { get; set; }
        public IList<Assignment>? Assignments { get; set; }
        public IList<Module>? Modules { get; set; }

        public Course()
        {

        }

        public override string ToString()
        {
            return $"({Code}) {Name}";
        }
    }
}
