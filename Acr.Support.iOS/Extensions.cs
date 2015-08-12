using System;
using System.Linq;
using UIKit;


namespace Acr.Support.iOS {

    public static class Extensions {

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
            var root = app.GetTopWindow().RootViewController;
            var tabs = root as UITabBarController;
			if (tabs != null) {
				root = tabs.PresentedViewController ?? tabs.SelectedViewController;

				while (root.PresentedViewController != null)
					root = GetTopViewController (root.PresentedViewController);

				return root;
			}

            var nav = root as UINavigationController;
            if (nav != null)
                return nav.VisibleViewController;

            while (root.PresentedViewController != null)
                root = GetTopViewController(root.PresentedViewController);

            return root;
        }


        static UIViewController GetTopViewController(UIViewController viewController) {
            if (viewController.PresentedViewController != null)
                return GetTopViewController(viewController.PresentedViewController);

            return viewController;
        }
    }
}
