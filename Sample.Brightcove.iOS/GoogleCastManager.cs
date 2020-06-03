using System;
using BrightcoveSDK.iOS;
using CoreGraphics;
using Foundation;
using Google.Cast;
using System.Linq;
using System.Collections.Generic;
using CoreMedia;

namespace Sample.Brightcove.iOS
{
    public abstract class GoogleCastManagerDelegate
    {
        public abstract BCOVPlaybackController playbackController { get; }

        public virtual void SwitchedToLocalPlayback(double lastKnownStreamPosition, NSObject error) { }
        public virtual void SwitchedToRemotePlayback() { }
        public virtual void CastedVideoFailedToPlay() { }
        public virtual void CurrentCastedVideoDidComplete() { }
        public virtual void SuitableSourceNotFound() { }
    }


    public class GoogleCastManager : NSObject
    {
        public GoogleCastManagerDelegate gcmDelegate;

        public SessionManager sessionManager;
        public UIMediaController castMediaController;
        public double currentProgress;
        public BCOVVideo currentVideo = null;
        public double castStreamPosition;
        public CGRect posterImageSize = new CGRect(0, 0, width: 480, height: 720);
        public bool didContinueCurrentVideo = false;
        public bool suitableSourceNotFound = false;
        public MediaInformation castMediaInfo;

        public GoogleCastManager()
        {
            sessionManager = CastContext.SharedInstance.SessionManager;
            castMediaController = new UIMediaController();
            sessionManager.AddListener(new XamSessionManagerListener(this));
            castMediaController.Delegate = new XamMediaControllerDelegate(this);
        }


        public BCOVSource FindPreferredSource(BCOVSource[] sources, bool withHTTPS)
        {

            //We prioritize HLS v3 > DASH > MP4
            var filteredSources = new List<BCOVSource>();
            foreach (var source in sources)
            {
                if (withHTTPS == true && source.Url.AbsoluteString.Contains("https://"))
                    filteredSources.Add(source);
                else
                {
                    if (source.Url.AbsoluteString.Contains("http://"))
                        filteredSources.Add(source);
                }
            }

            BCOVSource hlsSource = null;
            BCOVSource mp4Source = null;

            foreach (var source in filteredSources)
            {
                var urlString = source.Url.AbsoluteString;
                var deliveryMethod = source.DeliveryMethod;

                if (urlString.Contains("ac-3_avc1_ec-3"))
                {
                    hlsSource = source;
                    break;
                }

                if (urlString.Contains("hls/v3") && deliveryMethod.Equals("application/x-mpegURL"))
                {
                    hlsSource = source;
                    break;
                }

                if (deliveryMethod.Equals("video/mp4"))
                    mp4Source = source;
            }

            if (hlsSource != null)
            {
                Console.WriteLine("hlsSource");
                Console.WriteLine(hlsSource.Url.AbsoluteString);
                return hlsSource;
            }

            if (mp4Source != null)
            {
                Console.WriteLine("mp4Source");
                Console.WriteLine(mp4Source.Url.AbsoluteString);
                return mp4Source;
            }

            return null;
        }

        public BCOVSource FindDashSource(BCOVSource[] sources, bool withHTTPS)
        {

            //We prioritize HLS v3 > DASH > MP4
            var filteredSources = new List<BCOVSource>();
            foreach (var source in sources)
            {
                if (withHTTPS == true && source.Url.AbsoluteString.Contains("https://"))
                    filteredSources.Add(source);
                else
                {
                    if (source.Url.AbsoluteString.Contains("http://"))
                        filteredSources.Add(source);
                }
            }

            BCOVSource dashSource = null;

            foreach (var source in filteredSources)
            {
                var deliveryMethod = source.DeliveryMethod;

                if (deliveryMethod.Equals("application/dash+xml"))
                    dashSource = source;
            }

            if (dashSource != null)
            {
                Console.WriteLine("hlsSource");
                Console.WriteLine(dashSource.Url.AbsoluteString);
                return dashSource;
            }

            return null;
        }


        public void CreateMediaInfo(BCOVVideo video)
        {
            BCOVSource source = null;

            // Don't restart the current video
            if (currentVideo != null)
            {
                didContinueCurrentVideo = currentVideo.IsEqual(video);
                if (didContinueCurrentVideo)
                    return;
            }

            suitableSourceNotFound = false;

            // Try to find an HTTPS source first
            source = FindDashSource(video.Sources, true);

            if (source == null)
                source = FindDashSource(video.Sources, false);

            // If no source was able to be found, let the delegate know
            // and do not continue
            if (source == null)
            {
                suitableSourceNotFound = true;
                gcmDelegate.SuitableSourceNotFound();
                return;
            }

            currentVideo = video;

            var videoUrl = source.Url.AbsoluteString;
            var vname = video.Properties["name"];
            var durationNumber = video.Properties["duration"];

            var metaData = new MediaMetadata(MediaMetadataType.Generic);
            metaData.SetString(vname.ToString(), "kGCKMetadataKeyTitle");

            var poster = video.Properties["poster"].ToString();
            var posterUrl = new NSUrl(poster);
            metaData.AddImage(new Image(posterUrl, (nint)posterImageSize.Width, (nint)posterImageSize.Height));

            //TODO Implement this logic for closed caption cast
            //var mediaTracks = new List<MediaTrack>();
            //var textTracks = video.Properties["text_tracks"];
            //var trackIndentifier = 0;
            //foreach (var text in textTracks)
            //{
            //    trackIndentifier += 1;
            //    string src, lang, name, contentType, kind;
            //    if (text.Key.ToString() == "src")
            //        src = text.
            //    //string lang = text["srclang"] as string;
            //    //var name = text["label"] as string;
            //    //var contentType = text["mime_type"] as string;
            //}


            var builder = new MediaInformationBuilder();
            builder.ContentId = videoUrl;
            builder.StreamType = MediaStreamType.Unknown;
            builder.ContentType = source?.DeliveryMethod;
            builder.Metadata = metaData;
            builder.StreamDuration = (double)(durationNumber as NSNumber);
            //TODO uncomment this for closed caption cast
            //builder.MediaTracks = mediaTracks;

            castMediaInfo = builder.Build();

        }


        public void SetupRemoteMediaClientWithMediaInfo()
        {
            // Don't load media if the video is what is already playing
            // or if we couldn't find a suitable source for the video
            if (didContinueCurrentVideo || suitableSourceNotFound)
                return;

            if (gcmDelegate == null)
                return;

            var currentprogress = currentProgress;
            var playbackcontroller = gcmDelegate.playbackController;
            if (playbackcontroller == null)
                return;
            var options = new MediaLoadOptions();
            options.PlayPosition = currentprogress;
            options.Autoplay = playbackcontroller.AutoPlay;

            var castSession = CastContext.SharedInstance.SessionManager.CurrentSession;
            RemoteMediaClient remoteMediaClient = null;
            if (castSession != null)
                remoteMediaClient = castSession.RemoteMediaClient;
            if(castSession != null && remoteMediaClient != null && castMediaInfo != null)
                remoteMediaClient.LoadMedia(castMediaInfo, options);
            else
                Console.WriteLine("ERROR in SetupRemoteMediaClientWithMediaInfo");
        }

        public void SwitchToRemotePlayback()
        {
            // Pause local player
            gcmDelegate?.playbackController?.Pause();
            gcmDelegate?.SwitchedToRemotePlayback();
        }

        public void SwitchToLocalPlayback(NSError withError)
        {
            // Play local player
            var lastKnownStreamPosition = castMediaController.LastKnownStreamPosition;

            var playbackController = gcmDelegate?.playbackController;
            if (playbackController == null)
            {
                return;
            }

            playbackController.SeekToTime(new CMTime((long)lastKnownStreamPosition, 600), completionHandler: (arg0) =>
            {
                if (arg0)
                    gcmDelegate?.SwitchedToLocalPlayback(lastKnownStreamPosition, withError);
            });
        }
    }

    // MARK: - GCKSessionManagerListener

    public class XamSessionManagerListener : SessionManagerListener
    {
        GoogleCastManager googleCastManager;
        public XamSessionManagerListener(GoogleCastManager gcm)
        {
            this.googleCastManager = gcm;
        }

        public override void DidStartCastSession(SessionManager sessionManager, CastSession session)
        {
            //base.DidStartCastSession(sessionManager, session);
            googleCastManager.SwitchToRemotePlayback();
            googleCastManager.SetupRemoteMediaClientWithMediaInfo();
        }

        public override void DidStartSession(SessionManager sessionManager, Session session)
        {
            //base.DidStartSession(sessionManager, session);
            googleCastManager.SwitchToRemotePlayback();
            googleCastManager.SetupRemoteMediaClientWithMediaInfo();

        }

        public override void DidResumeSession(SessionManager sessionManager, Session session)
        {
            //base.DidResumeSession(sessionManager, session);
            googleCastManager.SwitchToRemotePlayback();
        }

        public override void DidEndSession(SessionManager sessionManager, Session session, NSError error)
        {
            //base.DidEndSession(sessionManager, session, error);
            googleCastManager.SwitchToLocalPlayback(error);
        }

        public override void DidFailToStartSession(SessionManager sessionManager, Session session, NSError error)
        {
            //base.DidFailToStartSession(sessionManager, session, error);
            googleCastManager.SwitchToLocalPlayback(error);
        }
    }


    // MARK: - BCOVPlaybackSessionConsumer

    public class XamBCPlaybackSessionConsumer : BCOVPlaybackSessionConsumer
    {
        GoogleCastManager googleCastManager;
        public XamBCPlaybackSessionConsumer(GoogleCastManager gcm)
        {
            this.googleCastManager = gcm;
        }

        //[Export("didAdvanceToPlaybackSession:")]
        //public void DidAdvanceToPlaybackSession(BCOVPlaybackSession session)
        //{
        //    //throw new System.NotImplementedException();
        //    googleCastManager.CreateMediaInfo(session.Video);
        //    googleCastManager.SetupRemoteMediaClientWithMediaInfo();
        //}

        public override void DidAdvanceToPlaybackSession(BCOVPlaybackSession session)
        {
            //base.DidAdvanceToPlaybackSession(session);
            googleCastManager.CreateMediaInfo(session.Video);
            googleCastManager.SetupRemoteMediaClientWithMediaInfo();
        }

        public override void PlaybackSessiondidProgressTo(BCOVPlaybackSession session, double progress)
        {
            //base.PlaybackSessiondidProgressTo(session, progress);
            googleCastManager.currentProgress = progress;
        }


        public override void PlaybackSession(BCOVPlaybackSession session, BCOVPlaybackSessionLifecycleEvent lifecycleEvent)
        {
            //base.PlaybackSession(session, lifecycleEvent);
            var sessionCheck = CastContext.SharedInstance.SessionManager.CurrentSession;
            if (sessionCheck != null)
            {
                if (lifecycleEvent.EventType == "kBCOVPlaybackSessionLifecycleEventReady")
                    googleCastManager.SwitchToRemotePlayback();
            }
        }
    }

    // MARK: - GCKUIMediaControllerDelegate
    public class XamMediaControllerDelegate : UIMediaControllerDelegate
    {
        GoogleCastManager googleCastManager;
        public XamMediaControllerDelegate(GoogleCastManager gcm)
        {
            this.googleCastManager = gcm;
        }

        public override void DidUpdateMediaStatus(UIMediaController mediaController, MediaStatus mediaStatus)
        {
            // Once the video has finished, let the delegate know
            // and attempt to proceed to the next session, if autoAdvance
            // is enabled

            if (mediaStatus != null)
            {
                if (mediaStatus.IdleReason == MediaPlayerIdleReason.Finished)
                {
                    googleCastManager.currentVideo = null;
                    var xdelegate = googleCastManager.gcmDelegate;
                    if (xdelegate == null)
                        return;

                    xdelegate.CurrentCastedVideoDidComplete();

                    var xplaybackController = xdelegate.playbackController;
                    if (xplaybackController != null)
                    {
                        if (xplaybackController.AutoAdvance)
                            xplaybackController.AdvanceToNext();
                    }
                }

                if (mediaStatus.IdleReason == MediaPlayerIdleReason.Error)
                {
                    googleCastManager.currentVideo = null;
                    var xdelegate = googleCastManager.gcmDelegate;
                    if (xdelegate == null)
                        return;

                    xdelegate.CastedVideoFailedToPlay();
                }

                googleCastManager.castStreamPosition = mediaStatus.StreamPosition;
            }
            else
                googleCastManager.castStreamPosition = 0;
        }
    }

}
