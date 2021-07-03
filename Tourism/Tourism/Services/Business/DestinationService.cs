using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class DestinationService : IDestinationService
    {
        private readonly IRestClientService _restClient;

        public DestinationService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<DestinationResponse> GetDestinationById(int Id)
        {
            var data = await _restClient.GetDestinationById(Id);
            return data;
        }

        public async Task<List<DestinationResponse>> GetDestinations()
        {
            var data = await _restClient.GetDestinations();
            return data;
        }
    }
}
