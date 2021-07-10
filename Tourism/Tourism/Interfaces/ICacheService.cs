using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tourism.Interfaces
{
    public interface ICacheService
    {
        Task SaveAppState(string key, IAppState appState);
        Task<IAppState> GetAppState(string key);
    }
}
