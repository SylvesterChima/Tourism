using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class EventService : IEventService
    {
        private readonly IRestClientService _restClient;

        public EventService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<EventResponse> GetEventDetails(int Id)
        {
            return await _restClient.GetEventDetails(Id);
        }

        public async Task<List<EventResponse>> GetEvents()
        {
            return await _restClient.GetEvents();
        }
    }
}
