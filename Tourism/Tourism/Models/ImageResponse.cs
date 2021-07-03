using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Tourism.Models
{

    [Preserve(AllMembers = true)]
    [AddINotifyPropertyChangedInterface]
    public class ImageResponse
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
