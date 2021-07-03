using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;
using Xamarin.Essentials;

namespace Tourism.ViewModels
{
    public partial class HotelDetailViewModel : BaseViewModel
    {
        public class Nav
        {
            public WhereToStayResponse WhereToStay { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;
                this.WhereToStay = this.Data.WhereToStay;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex, "An error occurred");
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }


        protected async override void ViewIsDisappearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        async void OnGoBack()
        {
            await this.CoreMethods.PopPageModel();
        }
        async void OnOpenMap()
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(this.WhereToStay.Address);
                var location = result.FirstOrDefault();
                if (location != null)
                {
                    await Map.OpenAsync(location.Latitude, location.Longitude);
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("Invalid address");
                }
            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex, "Something went wrong, please check if you map installed on your phone.");
            }
        }

        async void OnOpenLink()
        {
            try
            {
                await Browser.OpenAsync(this.WhereToStay.BookingLink, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex, "Something went wrong, please check if you map installed on your phone.");
            }
        }
    }
}

