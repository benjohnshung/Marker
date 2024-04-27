using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Marker.Models
{
    public class Submission
    {
        [Key] public string? Text { get; set; }
        
        public Person? Student { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            return $"{Student.Name} - Grade: {Grade} - Submission: {Text}";
        }
    }
}
