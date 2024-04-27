﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Marker.Models
{
    public class Module
    {
        [Key]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IList<ContentItem>? Content { get; set; }

        public override string ToString()
        {
            return $"Module: {Name} - {Description}";
        }
    }
}
