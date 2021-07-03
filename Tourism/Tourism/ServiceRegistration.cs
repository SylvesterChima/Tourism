using Acr.UserDialogs;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Services.Business;

namespace Tourism
{
    public class ServiceRegistration
    {
        public static void RegisterServices(App app)
        {
            FreshIOC.Container.Register<IApp>(app);
            FreshIOC.Container.Register<IErrorManager, ErrorManager>();
            FreshIOC.Container.Register<Acr.UserDialogs.IUserDialogs>(Acr.UserDialogs.UserDialogs.Instance);
            FreshIOC.Container.Register<IMessenger, FormsMessenger>();
            FreshIOC.Container.Register<IDestinationService, DestinationService>();
            FreshIOC.Container.Register<IAppState, AppState>();
            FreshIOC.Container.Register<IEventService, EventService>();
            FreshIOC.Container.Register<IImageService, ImageService>();
            FreshIOC.Container.Register<ICategoryService, CategoryService>();
            FreshIOC.Container.Register<IWhereToStayService, WhereToStayService>();
        }
    }
}
