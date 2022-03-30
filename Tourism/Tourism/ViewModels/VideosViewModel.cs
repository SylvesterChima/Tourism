using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Constants;
using Tourism.Models;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Tourism.ViewModels
{
    public partial class VideosViewModel : BaseViewModel
    {
        public async override Task Initialize(object initData)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();

                var youtube = new YoutubeClient();
                var videos = await youtube.Channels.GetUploadsAsync(PageConstants.YOUTUBE_CHANNEL_ID);
                var dt = new ObservableCollection<YoutubeVideo>();
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
                    this.Videos = dt;
                }
                else
                {
                    this.Videos = dt;
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


        public async void OnItemSelected(YoutubeVideo item)
        {
            if (item == null)
                return;
            var nav = new VideoPlayerViewModel.Nav
            {
                Video = item
            };
            await this.CoreMethods.PushPageModel<VideoPlayerViewModel>(nav);
        }
    }
}

