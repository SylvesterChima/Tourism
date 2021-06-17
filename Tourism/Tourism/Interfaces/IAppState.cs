using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface IAppState
    {
        List<DestinationResponse> Destinations { get; set; }
        List<EventResponse> Events { get; set; }
        List<ImageResponse> Images { get; set; }


        List<DestinationResponse> GetBanners();
        List<DestinationResponse> GetTopDestinations();
        List<EventResponse> GetRandomEvents();
        List<ImageResponse> GetRecentImages();

    }
}
