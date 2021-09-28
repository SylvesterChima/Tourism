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
        internal readonly IWhereToStayService _whereToStayService;


        public bool ShowAbout { get; set; } = true;
        public bool ShowPhoto { get; set; }
        public bool ShowVideo { get; set; }

        public Command GoBack { get; }
        public Command OpenMap { get; }
        public Command OpenLink { get; }
        public Command ViewAbout { get; }
        public Command ViewPhotos { get; }
        public Command ViewVideos { get; }

        public Nav Data { get; set; } = new Nav();
        public WhereToStayResponse WhereToStay { get; set; }
        public List<YoutubeVideo> YoutubeVideos { get; set; }
        public bool ShowBooking { 
            get
            {
                return !string.IsNullOrWhiteSpace(this.WhereToStay.BookingLink);
            }
        }

        public HotelDetailViewModel(IErrorManager errorManager, IMessenger messenger, IWhereToStayService whereToStayService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._whereToStayService = whereToStayService;

            GoBack = new Command(OnGoBack);
            OpenMap = new Command(OnOpenMap);
            OpenLink = new Command(OnOpenLink);
            ViewAbout = new Command(OnViewAbout);
            ViewPhotos = new Command(OnViewPhotos);
            ViewVideos = new Command(OnViewVideos);
        }
    }
}
