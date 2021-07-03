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
    public partial class DestinationPage : ContentPage
    {
        public DestinationPage()
        {
            InitializeComponent();
        }

        private async void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var model = this.BindingContext as DestinationViewModel;
            try
            {
                await model.ExecuteSearch(e.NewTextValue);
            }
            catch (Exception ex)
            {
                await model.ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }
    }
}