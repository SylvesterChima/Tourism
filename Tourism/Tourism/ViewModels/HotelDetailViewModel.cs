using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;
using Xamarin.Essentials;
using YoutubeExplode;
using YoutubeExplode.Common;

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
                //this.WhereToStay = this.Data.WhereToStay;
                UserDialogs.Instance.ShowLoading();


                this.WhereToStay = await _whereToStayService.GetWhereToStayDetails(this.Data.WhereToStay.Id);

                if (!string.IsNullOrWhiteSpace(this.Data.WhereToStay.YoutubePlayListId))
                {
                    if (this.Data.WhereToStay.YoutubePlayListId.Length >= 34)
                    {
                        var youtube = new YoutubeClient();
                        // Get all playlist videos "PLa1F2ddGya_-UvuAqHAksYnB0qL9yWDO6"
                        var videos = await youtube.Playlists.GetVideosAsync(this.Data.WhereToStay.YoutubePlayListId);
                        var dt = new List<YoutubeVideo>();
                        if (videos != null)
                        {
                            foreach (var item in videos)
                            {
                                dt.Add(new YoutubeVideo
                                {
                                    Id = item.Id.Value,
                                    Thumbnail = item.Thumbnails.FirstOrDefault()?.Url,
                                    Title = item.Title,
                                    VideoUrl = item.Url
                                });
                            }
                            this.YoutubeVideos = dt;
                        }
                        else
                        {
                            this.YoutubeVideos = dt;
                        }
                    }
                }

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
            this.ShowPhoto = false;
            this.ShowVideo = false;
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
        void OnViewPhotos()
        {
            HideViews();
            this.ShowPhoto = true;
        }
        void OnViewVideos()
        {
            HideViews();
            this.ShowVideo = true;
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
                if (Uri.IsWellFormedUriString(this.WhereToStay.BookingLink, UriKind.Absolute))
                {
                    await Browser.OpenAsync(this.WhereToStay.BookingLink, BrowserLaunchMode.SystemPreferred);
                }
            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex, "Something went wrong, please check if you map installed on your phone.");
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

        public async Task OpenVideo(YoutubeVideo video)
        {
            try
            {
                var nav = new VideoPlayerViewModel.Nav
                {
                    Video = video
                };
                await this.CoreMethods.PushPageModel<VideoPlayerViewModel>(nav);
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }
    }
}

