﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using BrightcoveGoogleCast.iOS;
using BrightcoveSDK.iOS;
using CoreGraphics;
using Foundation;
using Google.Cast;
using ObjCRuntime;
using UIKit;

namespace Sample.Brightcove.iOS
{
    public class CastVideoListViewController : UIViewController, ISessionManagerListener
    {
        static string policyKEY = "BCpkADawqM3n0ImwKortQqSZCgJMcyVbb8lJVwt0z16UD0a_h8MpEYcHyKbM8CGOPxBRp0nfSVdfokXBrUu3Sso7Nujv3dnLo0JxC_lNXCl88O7NJ0PR0z2AprnJ_Lwnq7nTcy1GBUrQPr5e";
        static string accountID = "4800266849001";
        static string videoId = "5754208017001";

        SessionManager sessionManager;
        UITableView table;
        UIView videoController;
        BCOVPlaybackController playbackController;
        BCOVPlayerSDKManager sDKManager = BCOVPlayerSDKManager.SharedManager();

        public CastVideoListViewController()
        {
            Title = "Cast List View";
        }

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

        public class BCGoogleCastManagerDelegate : BCOVGoogleCastManagerDelegate
        {
            BCOVPlaybackController controller;
            public BCGoogleCastManagerDelegate(BCOVPlaybackController controller)
            {
                this.controller = controller;
            }

            public override BCOVPlaybackController PlaybackController => controller;

            public override void SwitchedToLocalPlayback(NSObject lastKnownStreamPosition, NSObject error)
            {
                //base.SwitchedToLocalPlayback(lastKnownStreamPosition, error);
                var x = (NSNumber)lastKnownStreamPosition;
                if (x.Int32Value > 0)
                {
                    PlaybackController.Play();
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Google Cast button
            var castButton = new GCKUIButton(new CGRect(0, 0, 24, 24)) { TintColor = UIColor.White };
            NavigationItem.RightBarButtonItem = new UIBarButtonItem(castButton);



            /*
             * *
             * NotificationCenter.default.addObserver(self, selector: #selector(self.castStateDidChange),
                                               name: NSNotification.Name.gckCastStateDidChange,
                                               object: GCKCastContext.sharedInstance())
              *
              */


            //NSNotificationCenter.DefaultCenter.AddObserver(this,castDidChangeState(),CastContext.CastStateDidChangeNotification, CastContext.SharedInstance);

            sessionManager = CastContext.SharedInstance.SessionManager;
            sessionManager.AddListener(this);

            videoController = new UIView();
            videoController.BackgroundColor = UIColor.Red;
            videoController.Frame = new CGRect(0, 100, 375, 207.5);

            table = new UITableView(); // defaults to Plain style
            table.Frame = new CGRect(0, 335, View.Frame.Width, View.Frame.Height - 215);
            string[] tableItems = new string[] { "Basic Video", "DRM Video" };
            table.Source = new TableSource(tableItems, this);

            //playbackController Setup
            playbackController = sDKManager.CreatePlaybackController();
            playbackController.SetAutoPlay(true);
            playbackController.SetAutoAdvance(true);
            playbackController.Delegate = new BCPlaybackControllerDelegate();

            BCOVGoogleCastManager googleCastManager = new BCOVGoogleCastManager();
            googleCastManager.Delegate = new BCGoogleCastManagerDelegate(playbackController);
            playbackController.AddSessionConsumer(googleCastManager);

            //playerView Setup
            var options = new BCOVPUIPlayerViewOptions() { PresentingViewController = this };
            var playerView = new BCOVPUIPlayerView(playbackController, options, BCOVPUIBasicControlView.BasicControlViewWithVODLayout());
            playerView.Frame = new CGRect(0, 0, 375, 207.5);

            playerView.PlaybackController = playbackController;
            videoController.AddSubview(playerView);
            View.AddSubview(videoController);
            View.AddSubview(table);
        }


        [Export("sessionManager:didStartSession:")]
        public void DidStartSession(SessionManager sessionManager, Session session)
        {
            Console.WriteLine("Session Started.");
        }

        [Export("sessionManager:didResumeSession:")]
        public void DidResumeSession(SessionManager sessionManager, Session session)
        {
            Console.WriteLine("Session Resumed.");
        }

        [Export("sessionManager:didEndSession:withError:")]
        public void DidEndSession(SessionManager sessionManager, Session session, NSError error)
        {
            Console.WriteLine("Session Ended.");
        }

        [Export("sessionManager:didFailToStartSession:withError:")]
        public void DidFailToStartSession(SessionManager sessionManager, Session session, NSError error)
        {
            Console.WriteLine("Session Failed");
        }
    }
}