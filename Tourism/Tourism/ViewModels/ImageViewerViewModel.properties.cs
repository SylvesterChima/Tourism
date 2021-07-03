using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class ImageViewerViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;


        public Nav Data { get; set; } = new Nav();
        public ImageResponse Image { get; set; }

        public ImageViewerViewModel(IErrorManager errorManager, IMessenger messenger)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
        }
    }
}
