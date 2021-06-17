using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class MyTripResponse
    {
        public int Id { get; set; }
        public string DestinationIds { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DestinationResponse> Destinations { get; set; }


    }
}
