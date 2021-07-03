using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Interfaces;
using Tourism.MessagerModels;
using Tourism.Utilities;
using Xamarin.Forms;

namespace Tourism
{
    public partial class MainPage : FlyoutPage
    {
        internal readonly IMessenger Messenger;
        public MainPage()
        {
            InitializeComponent();
            this.Messenger = FreshMvvm.FreshIOC.Container.Resolve<IMessenger>();
            SetupInterface();
        }

        public void SetupInterface()
        {
            Flyout = new FlyoutMenuPage();
            Detail = PageUtility.CreateHomePage();
        }

        protected override void OnAppearing()
        {
            Messenger.Subscribe<FlyoutMenuTapped>(this, OnShowFlyoutMenu);
        }

        protected override void OnDisappearing()
        {

            Messenger.Unsubscribe<FlyoutMenuTapped>(this);
        }

        protected void OnShowFlyoutMenu(object sender, FlyoutMenuTapped e)
        {
            try
            {
                IsPresented = !IsPresented;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
