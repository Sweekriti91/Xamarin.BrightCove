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
            var discoveryCriteria = new DiscoveryCriteria("0A6928D1");
            var options = new CastOptions(discoveryCriteria);
            CastContext.SetSharedInstance(options);
            Logger.SharedInstance.Delegate = new LoggerDelegate();


            var navigationController = new UINavigationController(new CastVideoListViewController());
            var castContainer = CastContext.SharedInstance.CreateCastContainerController(navigationController);
            castContainer.MiniMediaControlsItemEnabled = true;

            CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = castContainer;
            Window.MakeKeyAndVisible();
            return true;
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