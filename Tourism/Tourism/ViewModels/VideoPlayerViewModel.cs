using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Tourism.ViewModels
{
    public partial class VideoPlayerViewModel : BaseViewModel
    {
        public class Nav
        {
            public YoutubeVideo Video { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;
                this.Video = this.Data.Video;

                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(this.Video.Id);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(this.Video.Id);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                if (streamInfo != null)
                {
                    this.VideoUrl = streamInfo.Url;
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex, "An error occurred");
            }
        }

        public async Task CloseVideo()
        {
            try
            {
                await this.CoreMethods.PopPageModel();
            }
            catch (Exception ex)
            {
                await this.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {

            base.ViewIsAppearing(sender, e);
        }
    }
}
