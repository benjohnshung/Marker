using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public class Assignment
    {
        [Key]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public IList<Submission>? Submissions { get; set; }

        public override string ToString()
        {
            return $"{Name} - {TotalAvailablePoints} - {DueDate} - {Description}";
        }
    }
}
