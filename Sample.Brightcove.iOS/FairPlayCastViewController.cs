using System;
using System.Diagnostics;
using AVKit;
using BrightcoveGoogleCast.iOS;
using BrightcoveSDK.iOS;
using CoreGraphics;
using Foundation;
using Google.Cast;
using UIKit;

namespace Sample.Brightcove.iOS
{
    public class FairPlayCastViewController : UIViewController, ISessionManagerListener
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

        public class BCGoogleCastManagerDelegate : GoogleCastManagerDelegate
        {

            BCOVPlaybackController controller;
            public BCGoogleCastManagerDelegate(BCOVPlaybackController controller)
            {
                this.controller = controller;
            }

            public override BCOVPlaybackController playbackController => controller;

            public override void SwitchedToLocalPlayback(double lastKnownStreamPosition, NSObject error)
            {
                //base.SwitchedToLocalPlayback(lastKnownStreamPosition, error);
                var x = (NSNumber)lastKnownStreamPosition;
                if (x.Int32Value > 0)
                {
                    playbackController.Play();
                }

                Debug.WriteLine("Switched to Local Playback");
            }

            public override void SwitchedToRemotePlayback()
            {
                //base.SwitchedToRemotePlayback();
                Debug.WriteLine("Switched to Remote Playback");
            }

            public override void CurrentCastedVideoDidComplete()
            {
                //base.CurrentCastedVideoDidComplete();
                Debug.WriteLine("Current Cast Video Did Complete");
            }

            public override void CastedVideoFailedToPlay()
            {
                //base.CastedVideoFailedToPlay();
                Debug.WriteLine("Casted video Failed to play");
            }

            public override void SuitableSourceNotFound()
            {
                //base.SuitableSourceNotFound();
                Debug.WriteLine("Suitable Source not Found");
            }
        }

        static string policyKEY = "";
        static string accountID = "";
        string videoId = "";

        BCOVPlayerSDKManager sDKManager = BCOVPlayerSDKManager.SharedManager();
        BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);
        BCOVPlaybackController playbackController;

        public FairPlayCastViewController()
        {
            Title = "FairPlay Cast Sample";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var castButton = new UICastButton(new CGRect(0, 0, 24, 24));
            NavigationItem.RightBarButtonItem = new UIBarButtonItem(castButton);

            sessionManager = CastContext.SharedInstance.SessionManager;
            CastContext.SharedInstance.SessionManager.AddListener(this);
            NSNotificationCenter aNotificationCenter = NSNotificationCenter.DefaultCenter;
            aNotificationCenter.AddObserver(this, new ObjCRuntime.Selector("castDidChangeState:"), CastContext.CastStateDidChangeNotification, CastContext.SharedInstance);

            //setup fairplay stuffs
            var fairPlayAuthProxy = new BCOVFPSBrightcoveAuthProxy(null, null);
            var fps = sDKManager.CreateFairPlaySessionProviderWithAuthorizationProxy(fairPlayAuthProxy, null);

            //Create the playback controller
            playbackController = sDKManager.CreateFairPlayPlaybackControllerWithAuthorizationProxy(fairPlayAuthProxy);
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(false);
            playbackController.Delegate = new BCPlaybackControllerDelegate();

            //USING CUSTOM GoogleCastManager
            GoogleCastManager googleCastManager = new GoogleCastManager();
            googleCastManager.gcmDelegate = new BCGoogleCastManagerDelegate(playbackController);
            var gcmPlaybackSession = new XamBCPlaybackSessionConsumer(googleCastManager);
            playbackController.AddSessionConsumer(gcmPlaybackSession);

            //TODO use CAST STATE TO HIDE PLAYER WHEN IT IS IN CONNECTED MODE

            // Set up our player view. Create with a standard VOD layout.
            var options = new BCOVPUIPlayerViewOptions() { ShowPictureInPictureButton = true };
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
            playerView.Frame = new CGRect(0, 100, 375, 207.5);
            playerView.ControlsView.ProgressSlider.MinimumTrackTintColor = UIColor.Green;
            View.AddSubview(playerView);
        }

        [Export("castDidChangeState:")]
        private void castDidChangeState(NSNotification obj)
        {
            switch (CastContext.SharedInstance.CastState)
            {
                case CastState.NoDevicesAvailable:
                    Console.WriteLine("Cast Status: No Devices Available");
                    break;
                case CastState.NotConnected:
                    Console.WriteLine("Cast Status: Not Connected");
                    break;
                case CastState.Connecting:
                    Console.WriteLine("Cast Status: Connecting");
                    break;
                case CastState.Connected:
                    Console.WriteLine("Cast Status: Connected");
                    break;
            }
        }
    }
}
