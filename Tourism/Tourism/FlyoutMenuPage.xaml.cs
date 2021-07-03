using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourism
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }

        private void Home_Tapped(object sender, EventArgs e)
        {
            MainPage mRootDetailPage = (MainPage)(App.Current.MainPage);
            mRootDetailPage.Detail = PageUtility.CreateHomePage();
            mRootDetailPage.IsPresented = false;
        }

        private void Destination_Tapped(object sender, EventArgs e)
        {
            MainPage mRootDetailPage = (MainPage)(App.Current.MainPage);
            mRootDetailPage.Detail = PageUtility.CreateDestinationPage();
            mRootDetailPage.IsPresented = false;
        }

        private void Photos_Tapped(object sender, EventArgs e)
        {
            MainPage mRootDetailPage = (MainPage)(App.Current.MainPage);
            mRootDetailPage.Detail = PageUtility.CreatePhotoPage();
            mRootDetailPage.IsPresented = false;
        }

        private void Events_Tapped(object sender, EventArgs e)
        {
            MainPage mRootDetailPage = (MainPage)(App.Current.MainPage);
            mRootDetailPage.Detail = PageUtility.CreateEventsPage();
            mRootDetailPage.IsPresented = false;
        }

        private void Hotels_Tapped(object sender, EventArgs e)
        {
            MainPage mRootDetailPage = (MainPage)(App.Current.MainPage);
            mRootDetailPage.Detail = PageUtility.CreateHotelsPage();
            mRootDetailPage.IsPresented = false;
        }
    }
}