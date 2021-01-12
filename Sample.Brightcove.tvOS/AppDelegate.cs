using AVFoundation;
using Foundation;
using UIKit;

namespace Sample.Brightcove.tvOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // see https://developer.apple.com/documentation/avfoundation/avaudiosessioncategoryplayback
            // and https://developer.apple.com/documentation/avfoundation/avaudiosessionmodemovieplayback

            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback, AVAudioSessionCategoryOptions.DuckOthers);

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //fairplay player
            //Window.RootViewController = new TvViewController();
            // uncomment for BasicPlayer
            //Window.RootViewController = new BasicPlayerViewController();
            Window.RootViewController = new MainPageButtons();
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}

