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
    public partial class EventDetailViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IEventService _eventService;


        public bool ShowAbout { get; set; } = true;
        public bool ShowPhoto { get; set; }
        public bool ShowVideo { get; set; }

        public Command GoBack { get; }
        public Command ViewAbout { get; }
        public Command ViewPhotos { get; }
        public Command ViewVideos { get; }

        public Nav Data { get; set; } = new Nav();
        public EventResponse Event { get; set; }
        public List<YoutubeVideo> YoutubeVideos { get; set; }

        public EventDetailViewModel(IErrorManager errorManager, IMessenger messenger, IEventService eventService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._eventService = eventService;

            GoBack = new Command(OnGoBack);
            ViewAbout = new Command(OnViewAbout);
            ViewPhotos = new Command(OnViewPhotos);
            ViewVideos = new Command(OnViewVideos);
        }
    }
}
