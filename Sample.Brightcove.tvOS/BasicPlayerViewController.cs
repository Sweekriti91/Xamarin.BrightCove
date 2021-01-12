using System;
using System.Diagnostics;
using BrightcoveSDK.tvOS;
using Foundation;
using UIKit;

namespace Sample.Brightcove.tvOS
{
    public class BasicPlayerViewController : UIViewController
    {
        public class BCPlaybackControllerDelegate : BCOVPlaybackControllerDelegate
        {
            public override void DidAdvanceToPlaybackSession(IBCOVPlaybackController controller, BCOVPlaybackSession session)
            {
                Debug.WriteLine("ViewController Debug - Advanced to new session.");
            }

            public override void PlaybackSession(IBCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent)
            {
                Debug.WriteLine($"Event : {lifecycleEvent.EventType}");
            }
        }

        public BasicPlayerViewController()
        {
        }

        string policyKey = "";
        string accountID = "";
        string videoID = "";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var options = new BCOVTVPlayerViewOptions() { PresentingViewController = this, };
            var playerView = new BCOVTVPlayerView(options);
            var playbackController = BCOVPlayerSDKManager.SharedManager().CreatePlaybackController();
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(true);
            playbackController.SetWeakDelegate( new BCPlaybackControllerDelegate());

            BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKey);
            playbackService.FindVideoWithVideoID(videoID: videoID, parameters: new NSDictionary(), completionHandler: (arg1, arg2, arg3) =>
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
            playerView.ControlsView.ProgressView.MinimumTrackTintColor = UIColor.Blue;
            playerView.ShowView(BCOVTVShowViewType.Controls);
            View.AddSubview(playerView);
        }
    }
}
