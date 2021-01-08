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
            public override void DidAdvanceToPlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session)
            {
                Debug.WriteLine("ViewController Debug - Advanced to new session.");
            }

            public override void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent)
            {
                Debug.WriteLine($"Event : {lifecycleEvent.EventType}");
            }
        }

        public BasicPlayerViewController()
        {
        }


        static string policyKEY = "BCpkADawqM0T8lW3nMChuAbrcunBBHmh4YkNl5e6ZrKQwPiK_Y83RAOF4DP5tyBF_ONBVgrEjqW6fbV0nKRuHvjRU3E8jdT9WMTOXfJODoPML6NUDCYTwTHxtNlr5YdyGYaCPLhMUZ3Xu61L";
        static string accountID = "5434391461001";
        static string videoId = "6140448705001";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var options = new BCOVTVPlayerViewOptions() { PresentingViewController = this, };
            var playerView = new BCOVTVPlayerView(options);
            var playbackController = BCOVPlayerSDKManager.SharedManager().CreatePlaybackController();
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
            playerView.ControlsView.ProgressView.MinimumTrackTintColor = UIColor.Blue;
            playerView.ShowView(BCOVTVShowViewType.Controls);
            View.AddSubview(playerView);
        }
    }
}
