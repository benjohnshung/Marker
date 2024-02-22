using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public enum ClassificationType { Freshman, Sophomore, Junior, Senior }
    public class Person
    {
        public string? Name { get; set; }
        public ClassificationType? Classification { get; set; }
        public List<int>? Grades { get; set; }
        public Guid ID { get; set; }
        public IList<Course>? CurrentCourses { get; set; }


        public Person()
        {

        }

        public override string ToString()
        {
            return $"({ID}) {Classification} - {Name}";
        }

    }
}
