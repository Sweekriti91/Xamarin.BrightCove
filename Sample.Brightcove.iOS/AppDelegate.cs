using Foundation;
using UIKit;
using Google.Cast;
using System;

namespace Sample.Brightcove.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate, ILoggerDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // More Info @ https://developers.google.com/cast/docs/ios_sender/integrate#initialize_the_cast_context
            var discoveryCriteria = new DiscoveryCriteria("4F8B3483");
            var options = new CastOptions(discoveryCriteria);

            // CastContext coordinates all of the framework's activities.
            CastContext.SetSharedInstance(options);

            // Google Cast Logger
            Logger.SharedInstance.Delegate = this;


            // More Info @ https://developers.google.com/cast/docs/ios_sender/integrate#add_mini_controllers

            //Window.RootViewController = new BasicPlayerViewController();
            //var appStoryboard = UIStoryboard.FromName("Main", null);

            var navigationController = new UINavigationController(new CastVideoListViewController());
            var castContainer = CastContext.SharedInstance.CreateCastContainerController(navigationController);
            castContainer.MiniMediaControlsItemEnabled = true;

            // More Info @ https://developers.google.com/cast/docs/ios_sender/integrate#add_expanded_controller
            CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;

            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            Window.RootViewController = castContainer;

            //UINavigationController uINavigationController = new UINavigationController(new CastVideoListViewController());
            //Window.RootViewController = uINavigationController;

            Window.MakeKeyAndVisible();
            return true;
        }

        [Export("logMessage:fromFunction:")]
        void LogMessage(string message, string function)
        {
            Console.WriteLine($"{function} {message}");
        }

        // Property to control the visibility of the mini controller.
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

