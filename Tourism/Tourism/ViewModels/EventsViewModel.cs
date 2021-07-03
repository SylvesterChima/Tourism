using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.ViewModels
{
    public partial class EventsViewModel : BaseViewModel
    {

        public async override Task Initialize(object initData)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();

                this.Events = new ObservableCollection<EventResponse>(this.AppState.Events);

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


        public async void OnItemSelected(EventResponse item)
        {
            if (item == null)
                return;
            var nav = new EventDetailViewModel.Nav
            {
                Event = item
            };
            await this.CoreMethods.PushPageModel<EventDetailViewModel>(nav);
        }
    }
}
