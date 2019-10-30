using System;
using System.Diagnostics;
using AVKit;
using BrightcoveSDK.iOS;
using Foundation;
using UIKit;

namespace Sample.Brightcove.iOS
{
    public class BasicPlayerViewController : UIViewController
    {
        //TODO: change delegates from public to internal?
        public class BCPlaybackControllerDelegate : BCOVPlaybackControllerDelegate
        {
            public override void DidAdvanceToPlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session)
            {
                Debug.WriteLine("ViewController Debug - Advanced to new session.");
            }

            public override void PlaybackSessiondidProgressTo(BCOVPlaybackController controller, BCOVPlaybackSession session, double progress)
            {
                Debug.WriteLine($"Progress : {progress} seconds");
            }
        }

        public class BCUIPlaybackViewController : BCOVPUIPlayerViewDelegate
        {
            public override void PictureInPictureControllerDidStartPictureInPicture(AVPictureInPictureController pictureInPictureController)
            {
                Debug.WriteLine("pictureInPictureControllerDidStartPicture");
            }

            public override void PictureInPictureControllerDidStopPictureInPicture(AVPictureInPictureController pictureInPictureController)
            {
                Debug.WriteLine("pictureInPictureControllerDidStopPicture");
            }

            public override void PictureInPictureControllerWillStartPictureInPicture(AVPictureInPictureController pictureInPictureController)
            {
                Debug.WriteLine("pictureInPictureControllerWillStartPicture");
            }

            public override void PictureInPictureControllerWillStopPictureInPicture(AVPictureInPictureController pictureInPictureController)
            {
                Debug.WriteLine("pictureInPictureControllerWillStopPicture");
            }

            public override void PictureInPictureController(AVPictureInPictureController pictureInPictureController, NSError error)
            {
                Debug.WriteLine($"failedToStartPictureInPictureWithError : {error.LocalizedDescription}");
            }
        }

        static string policyKEY = "";
        static string accountID = "";
        string videoId = "";

        BCOVPlayerSDKManager sDKManager = BCOVPlayerSDKManager.SharedManager();
        BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);
        BCOVPlaybackController playbackController;

        public BasicPlayerViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Set up our player view. Create with a standard VOD layout.
            var options = new BCOVPUIPlayerViewOptions() { ShowPictureInPictureButton = true };
            playbackController = sDKManager.CreatePlaybackController();
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(true);
            playbackController.Delegate = new BCPlaybackControllerDelegate();
            var playerView = new BCOVPUIPlayerView(playbackController, options, BCOVPUIBasicControlView.BasicControlViewWithVODLayout());
            playerView.Delegate = new BCUIPlaybackViewController();

            playbackService.FindVideoWithVideoID(videoID: videoId, parameters: new NSDictionary(), completionHandler: (arg0, arg1, arg2) =>
            {
                if (arg0 != null)
                {
                    playbackController.SetVideos(NSArray.FromObjects(arg0));
                }
                else
                    Debug.WriteLine($"View Controller Debug - Error retrieving video : {arg2.LocalizedDescription} ");
            });

            playerView.PlaybackController = playbackController;
            playerView.Frame = View.Frame;
            playerView.ControlsView.ProgressSlider.MinimumTrackTintColor = UIColor.Green;
            View.AddSubview(playerView);
        }
    }

    
}
