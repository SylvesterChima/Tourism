using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourism.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoPlayerPage : ContentPage
	{
        private double width;
        private double height;

        public VideoPlayerPage ()
		    {
			      InitializeComponent ();
            myActivityIndicator.IsVisible = true;
		    }

        protected async override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    await Task.Delay(1500);
                    myMediaElement.Aspect = Aspect.AspectFill;
                }
                else
                {
                    await Task.Delay(1500);
                    myMediaElement.Aspect = Aspect.AspectFit;
                }
            }
        }

        private void MediaElement_MediaOpened(object sender, EventArgs e)
        {
            myActivityIndicator.IsVisible = false;
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            var model = this.BindingContext as VideoPlayerViewModel;
            try
            {
                myMediaElement.Stop();
                await model.CloseVideo();
            }
            catch (Exception ex)
            {
                await model.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }
    }
}