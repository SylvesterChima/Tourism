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
    public partial class VideosViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IAppState AppState;

        public Command ItemTapped { get; }

        public ObservableCollection<YoutubeVideo> Videos { get; set; }

        public VideosViewModel(IErrorManager errorManager, IMessenger messenger, IDestinationService destinationService, IAppState appState)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this.AppState = appState;

            ItemTapped = new Command<YoutubeVideo>(OnItemSelected);
        }
    }
}
