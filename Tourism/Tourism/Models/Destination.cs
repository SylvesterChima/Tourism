using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Models
{
    public class Destination
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string DefaultImage { get; set; }
        public List<DestinationImage> DestinationImages { get; set; }
    }
}
