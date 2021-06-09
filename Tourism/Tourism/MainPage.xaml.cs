using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Utilities;
using Xamarin.Forms;

namespace Tourism
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetupInterface();
        }

        public void SetupInterface()
        {
            Flyout = new FlyoutMenuPage();
            Detail = PageUtility.CreateHomePage();
        }
    }
}
