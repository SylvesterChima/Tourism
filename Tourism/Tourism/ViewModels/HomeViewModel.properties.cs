using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;
using Xamarin.Forms;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class HomeViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IDestinationService DestinationService;

        public Command<string> GoToDestinationCommand { get; }
        public Command<Destination> ItemTapped { get; }

        public List<Destination> Banners { get; set; }
        public List<Destination> TopDestinations { get; set; }
        public List<Destination> TrendingDestinations { get; set; }

        public HomeViewModel(IErrorManager errorManager, IMessenger messenger, IDestinationService destinationService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this.DestinationService = destinationService;

            GoToDestinationCommand = new Command<string>(OnDestinationClicked);
            ItemTapped = new Command<Destination>(OnItemSelected);
        }
    }
}
