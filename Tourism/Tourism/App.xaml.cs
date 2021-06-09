using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Tourism.Constants;
using Tourism.Interfaces;
using Tourism.Utilities;

namespace Tourism
{
    public partial class App : Application, IApp
    {
        public static App Instance { get; private set; }
        public string CurrentAccessToken { get; set; }

        public App()
        {
            InitializeComponent();

            ServiceRegistration.RegisterServices(this);
            MainPage = PageUtility.CreateRootPage();
        }

        protected override void OnStart()
        {
            // Setup App Center
            AppCenter.Start($"ios={PageConstants.APPCENTER_IOS_KEY};android={PageConstants.APPCENTER_ANDROID_KEY}", typeof(Analytics), typeof(Crashes));
            Instance = this;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
