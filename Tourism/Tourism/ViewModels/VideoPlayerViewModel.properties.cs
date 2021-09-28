using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class VideoPlayerViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;


        public Nav Data { get; set; } = new Nav();
        public YoutubeVideo Video { get; set; }
        public string VideoUrl { get; set; }

        public VideoPlayerViewModel(IErrorManager errorManager, IMessenger messenger)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
        }
    }
}
