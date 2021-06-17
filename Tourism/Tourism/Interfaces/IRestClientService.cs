using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    [Headers("User-Agent: Enugu Tourism", "Authorization: Bearer")]
    public interface IRestClientService
    {
        [Get("/api/Destinations")]
        Task<List<DestinationResponse>> GetDestinations();

        [Get("/api/Images")]
        Task<List<ImageResponse>> GetImages();

        [Get("/api/Events")]
        Task<List<EventResponse>> GetEvents();
    }
}
