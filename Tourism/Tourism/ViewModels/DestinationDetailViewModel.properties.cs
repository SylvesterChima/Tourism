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
    public partial class DestinationDetailViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IDestinationService _destinationService;


        public Nav Data { get; set; } = new Nav();
        public DestinationResponse Destination { get; set; }
        public bool ShowAbout { get; set; } = true;
        public bool ShowNearby { get; set; }
        public bool ShowPhoto { get; set; }
        public bool ShowFestival { get; set; }
        public bool ShowHotel { get; set; }


        public Command GoBack { get; }
        public Command ViewAbout { get; }
        public Command ViewNearby { get; }
        public Command ViewPhotos { get; }
        public Command ViewFestival { get; }
        public Command ViewHotel { get; }
        public Command OpenMap { get; }
        public Command OpenDirection { get; }


        public DestinationDetailViewModel(IErrorManager errorManager, IMessenger messenger, IDestinationService destinationService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._destinationService = destinationService;

            GoBack = new Command(OnGoBack);
            ViewAbout = new Command(OnViewAbout);
            ViewNearby = new Command(OnViewNearby);
            ViewPhotos = new Command(OnViewPhotos);
            ViewFestival = new Command(OnViewFestival);
            ViewHotel = new Command(OnViewHotel);
            OpenMap = new Command(OnOpenMap);
            OpenDirection = new Command(OnOpenDirection);


        }
    }

}
