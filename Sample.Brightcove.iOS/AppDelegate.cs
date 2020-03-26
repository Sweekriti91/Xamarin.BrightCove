using Foundation;
using UIKit;

namespace Sample.Brightcove.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            //Window.RootViewController = new BasicPlayerViewController();
            Window.RootViewController = new BasicPlayerCastViewController();
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}

