using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tourism.Interfaces;
using Xamarin.Forms;

namespace Tourism.Services.Business
{
    public class ErrorManager : IErrorManager
    {
        public ErrorManager()
        {

        }

        public async Task DisplayErrorMessageAsync(Exception ex, string errorMessage = null)
        {
            //log exception
            LogException(ex);


            //handle general network errors
            if (ex.Message.ToLower().Contains("nsurl"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "We are unable to connect at this time. Please check your network connection.", "Ok");
            }
            else
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                }

            }

        }

        public void LogException(Exception ex, bool rethrow = false, [CallerMemberName] string caller = "")
        {
            //log exception

            var properties = new Dictionary<string, string> {
                { "Category", "Music" },
                { "Wifi", "On" }
            };
            Crashes.TrackError(ex, properties);

            if (rethrow)
            {
                throw ex;
            }
        }
    }
}
