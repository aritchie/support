using System;
using System.Threading;
using Android.App;


namespace Acr.Support.Android {

    public static class Extensions {

        public static void RequestMainThread(Action action) {
            if (Application.SynchronizationContext == SynchronizationContext.Current)
                action();
            else
                Application.SynchronizationContext.Post(x => {
                    try {
                        action();
                    }
                    catch { }
                }, null);
        }
    }
}