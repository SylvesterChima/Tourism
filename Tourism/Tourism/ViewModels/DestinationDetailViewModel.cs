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
    public partial class DestinationDetailViewModel : BaseViewModel
    {
        public class Nav
        {
            public int DestinationId { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;
                UserDialogs.Instance.ShowLoading();


                this.Destination = await _destinationService.GetDestinationById(this.Data.DestinationId);

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

        void HideViews()
        {
            this.ShowAbout = false;
            this.ShowFestival = false;
            this.ShowNearby = false;
            this.ShowPhoto = false;
            this.ShowHotel = false;
        }

        async void OnGoBack()
        {
            await this.CoreMethods.PopPageModel();
        }
        void OnViewAbout()
        {
            HideViews();
            this.ShowAbout = true;
        }
        void OnViewNearby()
        {
            HideViews();
            this.ShowNearby = true;
        }
        void OnViewPhotos()
        {
            HideViews();
            this.ShowPhoto = true;
        }
        void OnViewFestival()
        {
            HideViews();
            this.ShowFestival = true;
        }
        void OnViewHotel()
        {
            HideViews();
            this.ShowHotel = true;
        }

        async void OnOpenMap()
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(this.Destination.Address);
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

        async void OnOpenDirection()
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(this.Destination.Address);
                var location = result.FirstOrDefault();
                if (location != null)
                {
                    await Map.OpenAsync(location.Latitude, location.Longitude, new MapLaunchOptions { Name = this.Destination.Address, NavigationMode = NavigationMode.Driving });
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

        public async Task OpenNearByDestination(int destinationId)
        {
            try
            {
                var nav = new Nav
                {
                    DestinationId = destinationId
                };
                await this.CoreMethods.PushPageModel<DestinationDetailViewModel>(nav);
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        public async Task OpenPhoto(ImageResponse image)
        {
            try
            {
                var nav = new ImageViewerViewModel.Nav
                {
                    Image = image
                };
                await this.CoreMethods.PushPageModel<ImageViewerViewModel>(nav);
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        public async Task OpenFestival(FestivalResponse festival)
        {
            try
            {
                var eventObj = new EventResponse
                {
                    About = festival.About,
                    StartDate = festival.StartDate,
                    EndDate = festival.EndDate,
                    Id = festival.EventId,
                    ImageUrl = festival.ImageUrl,
                    Location = festival.Location,
                    Name = festival.Name
                };
                var nav = new EventDetailViewModel.Nav
                {
                    Event = eventObj
                };
                await this.CoreMethods.PushPageModel<EventDetailViewModel>(nav);
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        public async Task OpenHotel(StayResponse stay)
        {
            try
            {
                var stayObj = new WhereToStayResponse
                {
                    Id = stay.WhereToStayId,
                    ImageUrl = stay.ImageUrl,
                    Name = stay.Name,
                    AddedBy = stay.AddedBy,
                    BookingLink = stay.BookingLink,
                    Address = stay.Address,
                    Email = stay.Email,
                    Phone1 = stay.Phone1,
                    Phone2 = stay.Phone2,
                    Website = stay.Website
                };
                var nav = new HotelDetailViewModel.Nav
                {
                    WhereToStay = stayObj
                };
                await this.CoreMethods.PushPageModel<HotelDetailViewModel>(nav);
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }
    }
}
