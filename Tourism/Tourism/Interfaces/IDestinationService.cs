using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface IDestinationService
    {
        Task<List<DestinationResponse>> GetDestinations();
        Task<DestinationResponse> GetDestinationById(int Id);
    }
}
