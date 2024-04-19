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
        public int Id { get; set; }
        public IList<Course> CurrentCourses { get; set; }


        public Person()
        {
            CurrentCourses = new List<Course>();
        }

        public override string ToString()
        {
            return $"({Id}) {Classification} - {Name}";
        }

    }
}
