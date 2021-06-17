﻿using Refit;
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
            var restClient = RestService.For<IRestClientService>("http://192.168.43.167", new RefitSettings
            {
                AuthorizationHeaderValueGetter = async () => await Task.FromResult(token)
            });
            return restClient;
        }
    }
}