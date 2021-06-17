using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourism.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        double _titleTextTop;
        public HomePage()
        {
            InitializeComponent();
            TheScroll.PropertyChanged += OnScrollViewPropertyChanged;
            csvBanners.SizeChanged += OncsvBannersSizeChanged;
            TitleText.SizeChanged += OnTitleTextSizeChanged;
        }

        private void OnTitleTextSizeChanged(object sender, System.EventArgs e)
        {
            TitleText.SizeChanged -= OnTitleTextSizeChanged;

            //As soon as the news header has been repositioned, we can grab the actual screen top position
            _titleTextTop = TitleText.Y;

            //Remark: GetScreenCoordinates will get the actual position on screen instead of the actual position inside the parent
            //_titleTextTop = GetScreenCoordinates(TitleText).Y;
        }

        private void OncsvBannersSizeChanged(object sender, System.EventArgs e)
        {
            csvBanners.SizeChanged -= OncsvBannersSizeChanged;

            //When the bear image has been loaded, reposition the news header to the bottom of this image
            TitleText.Margin = new Thickness(0, csvBanners.Height - 60, 0, 0);
        }

        private void OnScrollViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(ScrollView.ScrollYProperty.PropertyName))
            {
                var scrolled = ((ScrollView)sender).ScrollY;
                System.Diagnostics.Debug.WriteLine($"Y position: {scrolled.ToString()}");

                if (scrolled < _titleTextTop)
                {
                    TitleText.TranslationY = (0 - scrolled);
                    TitleText.IsVisible = false;
                    TitleText.BackgroundColor = Color.Transparent;
                }
                else
                {
                    TitleText.TranslationY = (0 - _titleTextTop);
                    TitleText.IsVisible = true;
                    TitleText.BackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
                }
            }
        }
    }
}