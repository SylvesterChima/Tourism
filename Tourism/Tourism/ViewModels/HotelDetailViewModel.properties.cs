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
    public partial class HotelDetailViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;

        public Command GoBack { get; }
        public Command OpenMap { get; }
        public Command OpenLink { get; }

        public Nav Data { get; set; } = new Nav();
        public WhereToStayResponse WhereToStay { get; set; }
        public bool ShowBooking { 
            get
            {
                return !string.IsNullOrWhiteSpace(this.WhereToStay.BookingLink);
            }
        }

        public HotelDetailViewModel(IErrorManager errorManager, IMessenger messenger)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;

            GoBack = new Command(OnGoBack);
            OpenMap = new Command(OnOpenMap);
            OpenLink = new Command(OnOpenLink);
        }
    }
}
