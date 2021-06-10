using System;
using Tourism;
using Tourism.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(myScrollView), typeof(MyScrollViewRender))]
namespace Tourism.iOS
{
    public class MyScrollViewRender: ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                this.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
            }
        }
    }
}
