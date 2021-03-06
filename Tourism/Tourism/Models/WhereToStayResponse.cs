using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tourism.Models
{
    public class WhereToStayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string BookingLink { get; set; }
        public string ImageUrl { get; set; }
        public string AddedBy { get; set; }
        public DateTime Date { get; set; }
        public string YoutubePlayListId { get; set; }

        public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();
    }
}
