using System;
using System.Diagnostics;
using System.Drawing;
using AVKit;
using Brightcove.Forms;
using Brightcove.Forms.iOS.Renderers;
using BrightcoveSDK.iOS;
using CoreGraphics;
using Foundation;
using Google.Cast;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(PlayerPage), typeof(PlayerPageRenderer))]
namespace Brightcove.Forms.iOS.Renderers
{
    public class PlayerPageRenderer : PageRenderer
    {
        static string policyKEY = "";
        static string accountID = "";
        static string videoId = "";

        BCOVPlayerSDKManager sDKManager = BCOVPlayerSDKManager.SharedManager();
        BCOVPlaybackService playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);
        BCOVPlaybackController playbackController;
        BCOVPUIPlayerView playerView;


        public PlayerPageRenderer()
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);



            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetupEventsAndHooks();
                SetupUserInterface();
                StartVideoPlayback();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {ex.Message}");
            }
        }

        void StartVideoPlayback()
        {
            playbackService.FindVideoWithVideoID(videoID: videoId, parameters: new NSDictionary(), completionHandler: (arg0, arg1, arg2) =>
            {
                if (arg0 != null)
                {
                    playbackController.SetVideos(NSArray.FromObjects(arg0));
                }
                else
                    Debug.WriteLine($"View Controller Debug - Error retrieving video : {arg2.LocalizedDescription} ");
            });
        }

        void SetupUserInterface()
        {

            playbackService = new BCOVPlaybackService(accountId: accountID, policyKey: policyKEY);
            playerView.Frame = new CGRect(0, 100, 375, 207.5);
            playerView.ControlsView.ProgressSlider.MinimumTrackTintColor = UIColor.Green;
            View.AddSubview(playerView);

            var castButton = new UICastButton(new CGRect(50, 20, 24, 24));
            View.AddSubview(castButton);
        }

        void SetupEventsAndHooks()
        {
            //NSNotificationCenter aNotificationCenter = NSNotificationCenter.DefaultCenter;
            //aNotificationCenter.AddObserver(this, new ObjCRuntime.Selector("castDidChangeState:"), CastContext.CastStateDidChangeNotification, CastContext.SharedInstance);

            var fairPlayAuthProxy = new BCOVFPSBrightcoveAuthProxy(null, null);
            var fps = sDKManager.CreateFairPlaySessionProviderWithAuthorizationProxy(fairPlayAuthProxy, null);

            //Create the playback controller
            playbackController = sDKManager.CreateFairPlayPlaybackControllerWithAuthorizationProxy(fairPlayAuthProxy);
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(false);
            playbackController.Delegate = new BCPlaybackControllerDelegate();

            //USING CUSTOM GoogleCastManager
            GoogleCastManager googleCastManager = new GoogleCastManager();
            var gcmPlaybackSession = new XamBCPlaybackSessionConsumer(googleCastManager);
            googleCastManager.gcmDelegate = new XamGoogleCastManagerDelegate(playbackController);
            playbackController.AddSessionConsumer(gcmPlaybackSession);

            // Set up our player view. Create with a standard VOD layout.
            var options = new BCOVPUIPlayerViewOptions() { ShowPictureInPictureButton = true };
            playerView = new BCOVPUIPlayerView(playbackController, options, BCOVPUIBasicControlView.BasicControlViewWithVODLayout());
            playerView.Delegate = new BCUIPlaybackViewController();
            playerView.PlaybackController = playbackController;
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

        public class BCPlaybackControllerDelegate : BCOVPlaybackControllerDelegate
        {
            public async override void DidAdvanceToPlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session)
            {
                Debug.WriteLine("ViewController Debug - Advanced to new session.");
            }

            public override void PlaybackSessiondidProgressTo(BCOVPlaybackController controller, BCOVPlaybackSession session, double progress)
            {
                Debug.WriteLine($"Progress : {progress} seconds");
            }

            public async override void PlaybackSession(BCOVPlaybackController controller, BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent)
            {

                Debug.WriteLine("Lifecycle Activity " + lifecycleEvent);

            }
        }

        public class BCUIPlaybackViewController : BCOVPUIPlayerViewDelegate
        {

            public override void PlayerViewdidTransitionToScreenMode(BCOVPUIPlayerView playerView, BCOVPUIScreenMode screenMode)
            {
                //base.PlayerViewdidTransitionToScreenMode(playerView, screenMode);
                Debug.WriteLine("PlayerViewdidTransitionToScreenMode");
            }

            public override void PlayerView(BCOVPUIPlayerView playerView, BCOVPUIScreenMode screenMode)
            {
                //base.PlayerView(playerView, screenMode);
                Debug.WriteLine("PlayerView");
            }

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

        public class XamGoogleCastManagerDelegate : GoogleCastManagerDelegate
        {
            BCOVPlaybackController controller;
            public XamGoogleCastManagerDelegate(BCOVPlaybackController controller)
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

                if (error != null)
                    Debug.WriteLine("SWITCH TO LOCAL PLAYBACK WITH ERROR :: " + error);
            }

            public override void SwitchedToRemotePlayback()
            {
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
    }
}
