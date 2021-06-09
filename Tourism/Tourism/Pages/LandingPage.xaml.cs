using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourism.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            OpenMenuView();
        }

        async void OpenMenuView()
        {
            
            await bgContainer.FadeTo(0);
            bgContainer.IsVisible = true;
            await Task.Delay(1000);
            await bgContainer.FadeTo(1, 2000, Easing.Linear);
        }

    }
}