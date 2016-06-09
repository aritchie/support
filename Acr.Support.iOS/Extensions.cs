using System;
using System.Linq;
using UIKit;


namespace Acr.Support.iOS
{

    public static class Extensions
    {
        public static UIWindow GetTopWindow(this UIApplication app)
        {
            return app
                .Windows
                .Reverse()
                .FirstOrDefault(x =>
                    x.WindowLevel == UIWindowLevel.Normal &&
                    !x.Hidden
                );
        }


        public static UIView GetTopView(this UIApplication app)
        {
            return app.GetTopWindow().Subviews.Last();
        }


        public static UIViewController GetTopViewController(this UIApplication app)
        {
            var viewController = app.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return viewController;
        }
    }
}
