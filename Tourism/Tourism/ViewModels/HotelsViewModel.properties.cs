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
    public partial class HotelsViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IAppState AppState;
        internal readonly IWhereToStayService _whereToStay;


        public Command ItemTapped { get; }

        public ObservableCollection<WhereToStayResponse> WhereToStays { get; set; }


        public HotelsViewModel(IErrorManager errorManager, IMessenger messenger, IAppState appState, IWhereToStayService whereToStay)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this.AppState = appState;
            this._whereToStay = whereToStay;

            ItemTapped = new Command<WhereToStayResponse>(OnItemSelected);
        }
    }
}
