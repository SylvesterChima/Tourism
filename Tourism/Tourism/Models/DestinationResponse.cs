using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class DestinationResponse
    {
        public int Id { get; set; }
        public int DestinationCategoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Direction { get; set; }
        public int Visit { get; set; }
        public string AddedBy { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }

        public List<StayResponse> Stays { get; set; }
        public List<NearByResponse> Nears { get; set; }
        public List<FestivalResponse> Festivals { get; set; }
        public List<ImageResponse> Images { get; set; }
    }
}
