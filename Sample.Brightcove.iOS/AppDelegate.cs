using Foundation;
using UIKit;
using Google.Cast;
using System;

namespace Sample.Brightcove.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate, ILoggerDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var discoveryCriteria = new DiscoveryCriteria("4F8B3483");
            var options = new CastOptions(discoveryCriteria);
            CastContext.SetSharedInstance(options);
            Logger.SharedInstance.Delegate = this;


            var navigationController = new UINavigationController(new CastVideoListViewController());
            var castContainer = CastContext.SharedInstance.CreateCastContainerController(navigationController);
            castContainer.MiniMediaControlsItemEnabled = true;

            CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = castContainer;
            Window.MakeKeyAndVisible();
            return true;
        }

        [Export("logMessage:fromFunction:")]
        void LogMessage(string message, string function)
        {
            Console.WriteLine($"{function} {message}");
        }

        public bool CastControlBarsEnabled
        {
            get
            {
                var castContainer = Window.RootViewController as UICastContainerViewController;
                return castContainer.MiniMediaControlsItemEnabled;
            }
            set
            {
                var castContainer = Window.RootViewController as UICastContainerViewController;
                castContainer.MiniMediaControlsItemEnabled = value;
            }
        }
    }
}