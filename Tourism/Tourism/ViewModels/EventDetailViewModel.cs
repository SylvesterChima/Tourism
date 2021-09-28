using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Tourism.ViewModels
{
    public partial class EventDetailViewModel : BaseViewModel
    {
        public class Nav
        {
            public EventResponse Event { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;
                //this.Event = this.Data.Event;
                UserDialogs.Instance.ShowLoading();


                this.Event = await _eventService.GetEventDetails(this.Data.Event.Id);

                if (!string.IsNullOrWhiteSpace(this.Data.Event.YoutubePlayListId))
                {
                    if (this.Data.Event.YoutubePlayListId.Length >= 34)
                    {
                        var youtube = new YoutubeClient();
                        // Get all playlist videos "PLa1F2ddGya_-UvuAqHAksYnB0qL9yWDO6"
                        var videos = await youtube.Playlists.GetVideosAsync(this.Data.Event.YoutubePlayListId);
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
