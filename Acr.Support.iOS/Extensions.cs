using System;
using System.Linq;
using UIKit;


namespace Acr.Support.iOS {

    public static class Extensions {

        //public static void Present(this UIApplication app, UIViewController controller, bool animated = true, Action action = null) {
        //    if (NSThread.Current.IsMainThread)
        //        PresentInternal(app, controller, animated, action);
        //    else
        //        app.InvokeOnMainThread(() => PresentInternal(app, controller, animated, action));
        //}


        //static void PresentInternal(UIApplication app, UIViewController controller, bool animated, Action action) {
        //    var top = app.GetTopViewController();
        //    if (controller.PopoverPresentationController != null) {
        //        var x = top.View.Bounds.Width / 2;
        //        var y = top.View.Bounds.Bottom;
        //        var rect = new CGRect(x, y, 0, 0);

        //        controller.PopoverPresentationController.SourceView = top.View;
        //        controller.PopoverPresentationController.SourceRect = rect;
        //        controller.PopoverPresentationController.PermittedArrowDirections = UIPopoverArrowDirection.Unknown;
        //    }
        //    top.PresentViewController(controller, animated, action);
        //}


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
            var viewController = app.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            return viewController;
        }
    }
}
