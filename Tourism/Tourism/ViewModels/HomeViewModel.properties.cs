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
    public partial class HomeViewModel
    {
        internal readonly IErrorManager ErrorManager;
        internal readonly IMessenger Messenger;
        internal readonly IDestinationService _destinationService;
        internal readonly IImageService _imageService;
        internal readonly IEventService _eventService;
        internal readonly ICategoryService _categoryService;
        internal readonly IAppState AppState;
        internal readonly ICacheService _cacheService;

        public Command<string> SeeAllCommand { get; }
        public Command<DestinationResponse> DestinationTapped { get; }
        public Command<ImageResponse> ImageItemTapped { get; }
        public Command<DestinationCategoryResponse> CategoryTapped { get; }
        public Command<EventResponse> EventTapped { get; }
        public Command ShowFlyout { get; }

        public List<DestinationResponse> Banners { get; set; } 
        public List<DestinationResponse> TopDestinations { get; set; }
        public List<ImageResponse> RecentImages { get; set; }
        public List<EventResponse> Events { get; set; }
        public List<DestinationCategoryResponse> Categories { get; set; }


        public bool ShowTopDestination
        {
            get 
            {
                if(TopDestinations != null)
                {
                    return TopDestinations.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ShowCategories
        {
            get
            {
                if (Categories != null)
                {
                    return Categories.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ShowPhotos
        {
            get
            {
                if (RecentImages != null)
                {
                    return RecentImages.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ShowEvents
        {
            get
            {
                if (Events != null)
                {
                    return Events.Count > 0;
                }
                else
                {
                    return false;
                }
            }
        }


        public HomeViewModel(IErrorManager errorManager, IMessenger messenger, IAppState appState, IDestinationService destinationService,
            IEventService eventService, IImageService imageService, ICategoryService categoryService, ICacheService cacheService)
        {
            this.ErrorManager = errorManager;
            this.Messenger = messenger;
            this._destinationService = destinationService;
            this.AppState = appState;
            this._eventService = eventService;
            this._imageService = imageService;
            this._categoryService = categoryService;
            this._cacheService = cacheService;

            SeeAllCommand = new Command<string>(OnSellAllClicked);
            DestinationTapped = new Command<DestinationResponse>(OnDestinationItemSelected);
            ImageItemTapped = new Command<ImageResponse>(OnImageItemSelected);
            CategoryTapped = new Command<DestinationCategoryResponse>(OnCateogrySelected);
            EventTapped = new Command<EventResponse>(OnEventSelected);
            ShowFlyout = new Command(OnShowFlyout);

        }
    }
}
