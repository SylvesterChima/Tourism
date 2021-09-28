using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Interfaces;
using Tourism.MessagerModels;
using Tourism.Models;

namespace Tourism.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        IAppState data = null;
        public async override Task Initialize(object initData)
        {
            try
            {
                data = await _cacheService.GetAppState("appdata");
                if(data != null)
                {
                    this.AppState.Destinations = data.Destinations;
                    this.AppState.Events = data.Events;
                    this.AppState.Images = data.Images;
                    this.AppState.Categories = data.Categories;
                }
                else
                {
                    UserDialogs.Instance.ShowLoading();
                }

                this.Banners = this.AppState.GetBanners();
                this.TopDestinations = this.AppState.GetTopDestinations();
                this.Events = this.AppState.GetRandomEvents();
                this.RecentImages = this.AppState.GetRecentImages();
                this.Categories = this.AppState.GetRandomCategories();

                
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
                this.AppState.Destinations = await _destinationService.GetDestinations();
                this.AppState.Events = await _eventService.GetEvents();
                this.AppState.Images = await _imageService.GetImages();
                this.AppState.Categories = await _categoryService.GetCategories();
                await _cacheService.SaveAppState("appdata", this.AppState);
                if (data == null)
                {
                    this.Banners = this.AppState.GetBanners();
                    this.TopDestinations = this.AppState.GetTopDestinations();
                    this.Events = this.AppState.GetRandomEvents();
                    this.RecentImages = this.AppState.GetRecentImages();
                    this.Categories = this.AppState.GetRandomCategories();
                }
                UserDialogs.Instance.HideLoading();
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

        async void OnSellAllClicked(string str)
        {
            if (string.IsNullOrEmpty(str))
                return;
            if(str == "Destinations")
            {
                var nav = new DestinationViewModel.Nav
                {
                    Category = "Destinations"
                };
                await this.CoreMethods.PushPageModel<DestinationViewModel>(nav);
            }
            else if (str == "Categories")
            {
                await this.CoreMethods.PushPageModel<CategoryViewModel>();
            }
            else if (str == "Photos")
            {
                await this.CoreMethods.PushPageModel<PhotoViewModel>();
            }
        }

        async void OnDestinationItemSelected(DestinationResponse item)
        {
            if (item == null)
                return;
            var nav = new DestinationDetailViewModel.Nav
            {
                DestinationId = item.Id,
                PlayListId = item.YoutubePlayListId
            };
            await this.CoreMethods.PushPageModel<DestinationDetailViewModel>(nav);
        }

        async void OnCateogrySelected(DestinationCategoryResponse item)
        {
            if (item == null)
                return;
            var nav = new DestinationViewModel.Nav
            {
                Category = item.Name
            };
            await this.CoreMethods.PushPageModel<DestinationViewModel>(nav);
        }
        async void OnEventSelected(EventResponse item)
        {
            if (item == null)
                return;
            var nav = new EventDetailViewModel.Nav
            {
                Event = item
            };
            await this.CoreMethods.PushPageModel<EventDetailViewModel>(nav);
        }

        async void OnImageItemSelected(ImageResponse item)
        {
            if (item == null)
                return;
            var nav = new ImageViewerViewModel.Nav
            {
                Image = item
            };
            await this.CoreMethods.PushPageModel<ImageViewerViewModel>(nav);
        }

        void OnShowFlyout()
        {
            Messenger.Send(new FlyoutMenuTapped());
        }
    }
}
