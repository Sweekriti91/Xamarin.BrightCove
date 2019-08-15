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

        static string policyKEY = "";
        static string accountID = "";
        string videoId = "";

        BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);

        BCOVFPSAuthorizationProxy fairPlayAuthProxy;
        BCOVPlaybackController playbackController;
        BCOVPlayerSDKManager sdkManager = BCOVPlayerSDKManager.SharedManager;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // If you're using Dynamic Delivery, you don't need to load
            // an application certificate. The FairPlay session will load an
            // application certificate for you if needed.
            // You can just load and play your FairPlay videos.

            // If you are using Dynamic Delivery, you can pass nil for the publisherId and applicationId,
            fairPlayAuthProxy = new BCOVFPSAuthorizationProxy();

            // Create chain of session providers
            //var psp = new BCOVPlaybackSessionProvider();
            //psp
            //var fps = sdkManager.CreateFairPlaySessionProviderWithAuthorizationProxy(fairPlayAuthProxy, null);

            // Create the playback controller
            playbackController = sdkManager.CreateFairPlayPlaybackControllerWithAuthorizationProxy(fairPlayAuthProxy);
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(true);
            playbackController.Delegate = new BCPlaybackControllerDelegate();

            //create the playerview
            var options = new BCOVTVPlayerViewOptions() { PresentingViewController = this, };
            var playerView = new BCOVTVPlayerView(options);
            playerView.PlaybackController = playbackController;
            playerView.Frame = View.Frame;
            View.AddSubview(playerView);

            playbackService.FindVideoWithVideoID(videoID: videoId, parameters: new NSDictionary(), completionHandler: (arg1, arg2, arg3) =>
            {
                if (arg1 != null)
                {
                    playbackController.SetVideos(NSArray.FromObjects(arg1));
                }
                else
                    Debug.WriteLine($"View Controller Debug - Error retrieving video : {arg3.LocalizedDescription} ");
            });

        }
    }
}
