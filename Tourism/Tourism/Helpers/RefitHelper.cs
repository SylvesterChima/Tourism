using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Interfaces;
using Xamarin.Essentials;

namespace Tourism.Helpers
{
    public static class RefitHelper
    {
        public static IRestClientService GetService()
        {
            var token = Preferences.Get("accessToken", string.Empty);
            //http://192.168.39.104
            var restClient = RestService.For<IRestClientService>("https://enugutourism.azurewebsites.net", new RefitSettings
            {
                AuthorizationHeaderValueGetter = async () => await Task.FromResult(token)
            });
            return restClient;
        }
    }
}
