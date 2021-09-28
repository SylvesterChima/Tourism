using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string About { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string DateString { get; set; }
        public string YoutubePlayListId { get; set; }

        public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();
    }
}
