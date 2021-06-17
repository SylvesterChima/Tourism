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
        internal readonly IDestinationService _destinationService;
        internal readonly IImageService _imageService;
        internal readonly IEventService _eventService;
        internal readonly IAppState AppState;

        public Command<string> GoToDestinationCommand { get; }
        public Command<DestinationResponse> ItemTapped { get; }
        public Command<ImageResponse> ImageItemTapped { get; }

        public List<DestinationResponse> Banners { get; set; }
        public List<DestinationResponse> TopDestinations { get; set; }
        public List<ImageResponse> RecentImages { get; set; }
        public List<EventResponse> Events { get; set; }

        public HomeViewModel(IErrorManager errorManager, IMessenger messenger, IAppState appState, IDestinationService destinationService,
            IEventService eventService, IImageService imageService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._destinationService = destinationService;
            this.AppState = appState;
            this._eventService = eventService;
            this._imageService = imageService;

            GoToDestinationCommand = new Command<string>(OnDestinationClicked);
            ItemTapped = new Command<DestinationResponse>(OnItemSelected);
            ImageItemTapped = new Command<ImageResponse>(OnImageItemSelected);
        }
    }
}
