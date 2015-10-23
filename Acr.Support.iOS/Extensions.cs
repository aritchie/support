using System;
using System.Linq;
using Foundation;
using UIKit;


namespace Acr.Support.iOS {

    public static class Extensions {

        public static void Present(this UIApplication app, UIViewController controller, bool animated = true, Action action = null) {
            if (NSThread.Current.IsMainThread)
                app.KeyWindow.RootViewController.PresentViewController(controller, animated, action);
            else
                app.InvokeOnMainThread(() => app.KeyWindow.RootViewController.PresentViewController(controller, animated, action));
        }


        public static UIWindow GetTopWindow(this UIApplication app) {
            return app
                .Windows
                .Reverse()
                .FirstOrDefault(x =>
                    x.WindowLevel == UIWindowLevel.Normal &&
                    !x.Hidden
                );
        }


        public static UIView GetTopView(this UIApplication app) {
            return app.GetTopWindow().Subviews.Last();
        }


        public static UIViewController GetTopViewController(this UIApplication app) {
            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return viewController;
        }
    }
}
