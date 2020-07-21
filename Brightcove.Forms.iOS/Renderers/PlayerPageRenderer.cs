﻿using System;
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

        //minicontroller
        UIView miniMediaControlsContainerView = new UIView();
        NSLayoutConstraint miniMediaControlsHeightConstraint = new NSLayoutConstraint();
        UIMiniMediaControlsViewController miniMediaControlsViewController;
        bool miniMediaControlsViewEnabled = false;

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
                SetupChromecast();
                SetupEventsAndHooks();
                SetupUserInterface();
                StartVideoPlayback();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {ex.Message}");
            }
        }

        void SetupChromecast()
        {
            var discoveryCriteria = new DiscoveryCriteria("17F1E2B1");
            var castOptions = new CastOptions(discoveryCriteria);
            CastContext.SetSharedInstance(castOptions);
            CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;

            //GLogger.SharedInstance.Delegate = new LoggerDelegate();
            //var navigationController = new UINavigationController(this);
            //var castContainer = CastContext.SharedInstance.CreateCastContainerController(this);
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

            miniMediaControlsContainerView.Frame = new CGRect(0, 400, View.Frame.Width, 45);
            View.AddSubview(miniMediaControlsContainerView);
            UpdateControlBarsVisibility();
            //InstallViewController(miniMediaControlsViewController, View);
            InstallViewController(miniMediaControlsViewController, miniMediaControlsContainerView);
        }

        void SetupEventsAndHooks()
        {
            NSNotificationCenter aNotificationCenter = NSNotificationCenter.DefaultCenter;
            aNotificationCenter.AddObserver(this, new ObjCRuntime.Selector("castDidChangeState:"), CastContext.CastStateDidChangeNotification, CastContext.SharedInstance);

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

            //Create MiniControllerGoogleCast
            var castContext = CastContext.SharedInstance;
            miniMediaControlsViewController = castContext.CreateMiniMediaControlsViewController();
            miniMediaControlsViewController.Delegate = new XamGoogleCastMiniControllerDelegate(this);
        }

        public void UpdateControlBarsVisibility()
        {
            Debug.WriteLine("miniMediaControlsViewController Active : " + miniMediaControlsViewController.Active);
            if (miniMediaControlsViewEnabled == true && miniMediaControlsViewController.Active)
            {
                miniMediaControlsContainerView.Hidden = false;
                View.BringSubviewToFront(miniMediaControlsContainerView);
            }
            else
                miniMediaControlsContainerView.Hidden = true;

            UIView.Animate(0.2, () =>
            {
                View.LayoutIfNeeded();
            });

            View.SetNeedsLayout();
        }

        public void InstallViewController(UIMiniMediaControlsViewController viewController, UIView containerView)
        {
            if (viewController != null)
            {
                this.ViewController.AddChildViewController(viewController);
                viewController.View.Frame = containerView.Bounds;
                containerView.AddSubview(viewController.View);
                viewController.DidMoveToParentViewController(this);
            }
        }

        //public void UninstallViewController(UIViewController viewController)
        //{
        //    viewController.WillMoveToParentViewController(null);
        //    viewController.View.RemoveFromSuperview();
        //    viewController.RemoveFromParentViewController();
        //}

        public class XamGoogleCastMiniControllerDelegate : UIMiniMediaControlsViewControllerDelegate
        {
            PlayerPageRenderer pageRenderer;

            public XamGoogleCastMiniControllerDelegate(PlayerPageRenderer pageR)
            {
                this.pageRenderer = pageR;
            }

            public override void ShouldAppear(UIMiniMediaControlsViewController miniMediaControlsViewController, bool shouldItAppear)
            {
                pageRenderer.UpdateControlBarsVisibility();
            }
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
                    miniMediaControlsViewEnabled = true;
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
                //base.SwitchedToRemotePlayback();
                // CastContext.SharedInstance.PresentDefaultExpandedMediaControls();
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