using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Interfaces;

namespace Tourism.Services.Business
{
    public class CacheService : ICacheService
    {
        public async Task<IAppState> GetAppState(string key)
        {
            var cacheState = Barrel.Current.Get<IAppState>(key: key);
            return cacheState;
        }

        public async Task SaveAppState(string key, IAppState appState)
        {
            Barrel.Current.Empty(key: key);
            Barrel.Current.Add(key: key, data: appState, expireIn: TimeSpan.FromDays(30));
        }
    }
}
