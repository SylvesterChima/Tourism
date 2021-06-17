using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DestinationDetailViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;

        public DestinationDetailViewModel(IErrorManager errorManager, IMessenger messenger)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
        }
    }
}
