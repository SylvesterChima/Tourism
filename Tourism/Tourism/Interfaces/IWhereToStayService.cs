using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface IWhereToStayService
    {
        Task<List<WhereToStayResponse>> GetWhereToStays();
        Task<WhereToStayResponse> GetWhereToStayDetails(int Id);
    }
}
