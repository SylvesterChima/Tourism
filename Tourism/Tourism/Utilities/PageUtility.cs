using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Constants;
using Tourism.Interfaces;
using Tourism.ViewModels;
using Xamarin.Forms;

namespace Tourism.Utilities
{
    public class PageUtility
    {
        public static Page CreateRootPage()
        {
            return new MainPage();
        }

        public static Page CreateHomePage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<HomeViewModel>();
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;

            nav.BarBackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
            nav.BarTextColor = Color.FromHex(PageConstants.White);

            return nav;
        }

        public static Page LandingPage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LandingViewModel>();
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;

            nav.BarBackgroundColor = Color.FromHex(PageConstants.Transparent);
            nav.BarTextColor = Color.FromHex(PageConstants.White);

            return nav;
        }

        public static Page CreateDestinationPage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            var navData = new DestinationViewModel.Nav
            {
                Category = "Destinations"
            };
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<DestinationViewModel>(navData);
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;
            nav.BarBackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
            nav.BarTextColor = Color.FromHex(PageConstants.White);
            return nav;
        }

        public static Page CreatePhotoPage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<PhotoViewModel>();
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;
            nav.BarBackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
            nav.BarTextColor = Color.FromHex(PageConstants.White);
            return nav;
        }

        public static Page CreateEventsPage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<EventsViewModel>();
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;
            nav.BarBackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
            nav.BarTextColor = Color.FromHex(PageConstants.White);
            return nav;
        }

        public static Page CreateHotelsPage()
        {

            IApp app = FreshMvvm.FreshIOC.Container.Resolve<IApp>();
            Page page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<HotelsViewModel>();
            NavigationPage nav = new FreshMvvm.FreshNavigationContainer(page) as NavigationPage;
            nav.BarBackgroundColor = Color.FromHex(PageConstants.PrimaryColor);
            nav.BarTextColor = Color.FromHex(PageConstants.White);
            return nav;
        }
    }
}
