using System;
using System.Collections.Generic;
using System.Text;
using Tourism.Pages;

namespace Tourism.Utilities
{
    public class NavigationUtility
    {
        public static void PopToPage(Type pPageType)
        {
            // Create root page
            MainPage mRootPageDetail = GetRootPageDetail();
            // Create detail page
            if (pPageType == typeof(HomePage))
            {
                mRootPageDetail.Detail = PageUtility.CreateHomePage();
            }
            else if (pPageType == typeof(DestinationPage))
            {
                mRootPageDetail.Detail = PageUtility.CreateDestinationPage();
            }
            else if (pPageType == typeof(PhotoPage))
            {
                mRootPageDetail.Detail = PageUtility.CreatePhotoPage();
            }
            else if (pPageType == typeof(EventsPage))
            {
                mRootPageDetail.Detail = PageUtility.CreateEventsPage();
            }
        }

        private static MainPage GetRootPageDetail()
        {
            // This method just removed any modals, since we just create the new navigation page. We still need to remove the modals.
            MainPage mRootPageDetail = App.Instance.MainPage as MainPage;

            // first check and clear the modal stack
            for (int i = mRootPageDetail.Detail.Navigation.ModalStack.Count - 1; i >= 0; i--)
            {
                var rootPage = mRootPageDetail.Detail.Navigation.ModalStack[i] as MainPage;

                if (rootPage == null)
                {
                    mRootPageDetail.Detail.Navigation.PopModalAsync(false);
                }
                else
                {
                    break;
                }
            }

            return mRootPageDetail;
        }
    }
}
