using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface IDestinationService
    {
        Task<List<Destination>> GetDestinations();
        Task<List<Destination>> GetBanners();
        Task<List<Destination>> GetTopDestinations();
        Task<List<Destination>> GetTrendingDestinations();
    }
}
