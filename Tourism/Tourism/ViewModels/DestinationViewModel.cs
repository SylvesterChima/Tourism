using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.ViewModels
{
    public partial class DestinationViewModel : BaseViewModel
    {
        public class Nav
        {
            public string Category { get; set; }
        }

        public async override Task Initialize(object initData)
        {
            try
            {
                var nav = initData as Nav;

                if (nav != null)
                    this.Data = nav;
                UserDialogs.Instance.ShowLoading();

                if(this.Data.Category != "Destinations")
                {
                    this.Destinations = new ObservableCollection<DestinationResponse>(this.AppState.Destinations.Where(c=>c.CategoryName == this.Data.Category));
                    this.MyDestinations = this.Destinations.ToList();
                }
                else
                {
                    this.Destinations = new ObservableCollection<DestinationResponse>(this.AppState.Destinations);
                    this.MyDestinations = this.AppState.Destinations;
                }

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex, "An error occurred");
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }


        protected async override void ViewIsDisappearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                await ErrorManager.DisplayErrorMessageAsync(ex);
            }
        }

        public async Task ExecuteSearch(string searchText)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    this.Destinations = new ObservableCollection<DestinationResponse>(this.MyDestinations.Where(c => c.Name.ToLower().Contains(searchText.ToLower()) ||
                                                                                        c.Area.ToLower().Contains(searchText.ToLower())));
                }
                else
                {
                    this.Destinations = new ObservableCollection<DestinationResponse>(this.MyDestinations);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await ErrorManager.DisplayErrorMessageAsync(ex, "An error occurred while loading page");
            }
        }

        public async void OnItemSelected(DestinationResponse item)
        {
            if (item == null)
                return;
            var nav = new DestinationDetailViewModel.Nav
            {
                DestinationId = item.Id,
                PlayListId = item.YoutubePlayListId
            };
            await this.CoreMethods.PushPageModel<DestinationDetailViewModel>(nav);
        }
    }
}
