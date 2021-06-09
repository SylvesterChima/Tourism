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
                Banners = await DestinationService.GetBanners();
                TopDestinations = await DestinationService.GetTopDestinations();
                TrendingDestinations = await DestinationService.GetTrendingDestinations();

                UserDialogs.Instance.HideLoading();
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

        async void OnItemSelected(Destination item)
        {
            if (item == null)
                return;

        }
    }
}
