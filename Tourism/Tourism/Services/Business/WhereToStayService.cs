using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class WhereToStayService : IWhereToStayService
    {
        private readonly IRestClientService _restClient;

        public WhereToStayService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<WhereToStayResponse> GetWhereToStayDetails(int Id)
        {
            return await _restClient.GetWhereToStayDetails(Id);
        }

        public async Task<List<WhereToStayResponse>> GetWhereToStays()
        {
            return await _restClient.GetWhereToStays();
        }
    }
}
