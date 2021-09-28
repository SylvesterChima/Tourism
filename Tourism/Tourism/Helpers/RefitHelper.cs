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
            //https://enugutourism.azurewebsites.net
            var restClient = RestService.For<IRestClientService>("http://enugu.city", new RefitSettings
            {
                AuthorizationHeaderValueGetter = async () => await Task.FromResult(token)
            });
            return restClient;
        }
    }
}
