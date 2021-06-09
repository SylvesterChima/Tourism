using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class LandingViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;

        public LandingViewModel(IErrorManager errorManager, IMessenger messenger)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
        }
    }
}
