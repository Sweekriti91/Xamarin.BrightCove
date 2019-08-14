using System;
using System.Diagnostics;
using BrightcoveSDK.tvOS;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Sample.Brightcove.tvOS
{
    public class TvViewController : UIViewController
    {
        public class BCPlaybackControllerDelegate : BCOVPlaybackControllerDelegate
        {
            public override void DidAdvanceToPlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session)
            {
                Debug.WriteLine("ViewController Debug - Advanced to new session.");
            }

            public override void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent)
            {
                Debug.WriteLine($"Event : {lifecycleEvent.EventType}");
            }
        }

        public TvViewController()
        {
        }

        string policyKEY = "BCpkADawqM3n0ImwKortQqSZCgJMcyVbb8lJVwt0z16UD0a_h8MpEYcHyKbM8CGOPxBRp0nfSVdfokXBrUu3Sso7Nujv3dnLo0JxC_lNXCl88O7NJ0PR0z2AprnJ_Lwnq7nTcy1GBUrQPr5e";
        string accountID = "4800266849001";
        string videoId = "5754208017001";


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var options = new BCOVTVPlayerViewOptions() { PresentingViewController = this,  };
            var playerView = new BCOVTVPlayerView(options);
            var playbackController = BCOVPlayerSDKManager.SharedManager.CreatePlaybackController();
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(true);
            playbackController.Delegate = new BCPlaybackControllerDelegate();

            BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);
            playbackService.FindVideoWithVideoID(videoID: videoId, parameters: new NSDictionary(), completionHandler: (arg1, arg2, arg3) =>
            {
                if (arg1 != null)
                {
                    playbackController.SetVideos(NSArray.FromObjects(arg1));
                }
                else
                    Debug.WriteLine($"View Controller Debug - Error retrieving video : {arg3.LocalizedDescription} ");
            });

            playerView.PlaybackController = playbackController;
            //playerView.TranslatesAutoresizingMaskIntoConstraints = false;
            playerView.Frame = View.Frame;
            View.AddSubview(playerView);
        }
    }
}
