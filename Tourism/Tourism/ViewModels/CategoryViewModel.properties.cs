using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;
using Xamarin.Forms;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class CategoryViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IDestinationService _destinationService;
        internal readonly IAppState AppState;

        public Command ItemTapped { get; }

        public ObservableCollection<DestinationCategoryResponse> Categories { get; set; }

        public CategoryViewModel(IErrorManager errorManager, IMessenger messenger, IDestinationService destinationService, IAppState appState)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._destinationService = destinationService;
            this.AppState = appState;

            ItemTapped = new Command<DestinationCategoryResponse>(OnItemSelected);
        }
    }
}
