using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class FestivalResponse
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
    }
}
