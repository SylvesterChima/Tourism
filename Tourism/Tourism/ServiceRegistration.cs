using Acr.UserDialogs;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Interfaces;
using Tourism.Services.Business;
using Tourism.Services.Mock;

namespace Tourism
{
    public class ServiceRegistration
    {
        public static void RegisterServices(App app)
        {
            FreshIOC.Container.Register<IApp>(app);
            FreshIOC.Container.Register<IErrorManager, ErrorManager>();
            FreshIOC.Container.Register<IMessenger, FormsMessenger>();
            FreshIOC.Container.Register<IDestinationService, DestinationMockService>();
        }
    }
}
