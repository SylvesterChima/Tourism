using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class ArticleViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IAppState AppState;
        internal readonly IArticleService _article;


        public ArticleResponse Article { get; set; }
        public string HtmlContent { get; set; }
        public Nav Data { get; set; } = new Nav();


        public ArticleViewModel(IErrorManager errorManager, IMessenger messenger, IAppState appState, IArticleService article)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this.AppState = appState;
            this._article = article;
        }
    }
}
