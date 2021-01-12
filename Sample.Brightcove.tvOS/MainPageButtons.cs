using System;
using CoreGraphics;
using UIKit;

namespace Sample.Brightcove.tvOS
{
    public partial class MainPageButtons : UIViewController
    {
        public MainPageButtons() : base("MainPageButtons", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var button = new UIButton(UIButtonType.System);
            button.Frame = new CGRect(25, 25, 300, 150);
            button.SetTitle("Play 1!", UIControlState.Normal);
            button.AllEvents += Button_AllEvents;


            var button2 = new UIButton(UIButtonType.System);
            button2.Frame = new CGRect(400, 25, 300, 150);
            button2.SetTitle("Play 2!", UIControlState.Normal);
            button2.AllEvents += Button2_AllEvents;

            var button3 = new UIButton(UIButtonType.System);
            button3.Frame = new CGRect(725, 25, 300, 150);
            button3.SetTitle("Play 3!", UIControlState.Normal);
            button3.AllEvents += Button3_AllEvents;


            this.View.AddSubview(button);
            this.View.AddSubview(button2);
            this.View.AddSubview(button3);
        }

        private async void Button2_AllEvents(object sender, EventArgs e)
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;


            var playerViewController = new TvViewController();
            await vc.PresentViewControllerAsync(playerViewController, true);
        }

        private async void Button_AllEvents(object sender, EventArgs e)
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;


            var playerViewController = new TvViewController();
            await vc.PresentViewControllerAsync(playerViewController, true);
        }

        private async void Button3_AllEvents(object sender, EventArgs e)
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;


            var playerViewController = new TvViewController();
            await vc.PresentViewControllerAsync(playerViewController, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

