using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        public async override Task Initialize(object initData)
        {
            try
            {
                //UserDialogs.Instance.ShowLoading();
                this.AppState.Destinations = await _destinationService.GetDestinations();
                this.AppState.Events = await _eventService.GetEvents();
                this.AppState.Images = await _imageService.GetImages();

                this.Banners = this.AppState.GetBanners();
                this.TopDestinations = this.AppState.GetTopDestinations();
                this.Events = this.AppState.GetRandomEvents();
                this.RecentImages = this.AppState.GetRecentImages();

                //UserDialogs.Instance.HideLoading();
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

        async void OnDestinationClicked(string str)
        {
            if (string.IsNullOrEmpty(str))
                return;
        }

        async void OnItemSelected(DestinationResponse item)
        {
            if (item == null)
                return;
            await this.CoreMethods.PushPageModel<DestinationDetailViewModel>();
        }

        async void OnImageItemSelected(ImageResponse item)
        {
            if (item == null)
                return;

        }
    }
}
