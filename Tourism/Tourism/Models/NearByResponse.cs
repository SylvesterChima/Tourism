using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class NearByResponse
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int DestinationId { get; set; }
        public decimal Kilometer { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
