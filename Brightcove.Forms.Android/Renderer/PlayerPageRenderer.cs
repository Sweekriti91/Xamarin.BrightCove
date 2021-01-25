using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Gms.Cast.Framework;
using Android.Views;
using Brightcove.Forms;
using Brightcove.Forms.Droid.Renderer;
using Com.Brightcove.Cast;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.Events;
using Com.Brightcove.Player.Model;
using Com.Brightcove.Player.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MediaRouteButton = Android.Support.V7.App.MediaRouteButton;

[assembly: ExportRenderer(typeof(PlayerPage), typeof(PlayerPageRenderer))]
namespace Brightcove.Forms.Droid.Renderer
{
    public class PlayerPageRenderer : PageRenderer
    {
        global::Android.Views.View view;
        Activity activity;

        static string policyKEY = "";
        static string accountID = "";
        string videoId = "";

        static BrightcoveExoPlayerVideoView brightcoveVideoView;
        static MediaRouteButton castButton;
        static GoogleCastComponent googleCastComponent;
        public static CastContext castContext;
        CastStateListener listenerCast;

        public PlayerPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetupUserInterface();
                AddView(view);
                SetupCast();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

        void SetupUserInterface()
        {
            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.activity_main, this, false);
            //activity.SetContentView(view);
            castContext = CastContext.SharedInstance;

            listenerCast = new CastStateListener();
            castContext.AddCastStateListener(listenerCast);

            brightcoveVideoView = view.FindViewById<BrightcoveExoPlayerVideoView>(Resource.Id.brightcove_video_view);
            var eventEmitter = brightcoveVideoView.EventEmitter;
            Catalog catalog = new Catalog(eventEmitter, accountID, policyKEY);

            catalog.FindVideoByID(videoID: videoId, new VideoListenerR());


            castButton = (MediaRouteButton)view.FindViewById(Resource.Id.media_route_button);
            castButton.SetBackgroundColor(Android.Graphics.Color.Aqua);
            CastButtonFactory.SetUpMediaRouteButton(Context, castButton);

            CustomCastMediaManager customCastMediaManager = new CustomCastMediaManager(Context, eventEmitter);
            googleCastComponent = new GoogleCastComponent(eventEmitter, Context, customCastMediaManager);

            // listen for cast started and ended events
            eventEmitter.On(GoogleCastEventType.CastSessionStarted, new CastSessionStartedListener());

        }

        public partial class VideoListenerR : VideoListener
        {
            public override void OnVideo(Video video)
            {
                brightcoveVideoView.Add(video);
                brightcoveVideoView.Start();
            }

            public override void OnError(string error)
            {
                throw new Java.Lang.RuntimeException(error);
            }
        }

        public void SetupCast()
        {
      

            Intent intent = new Intent();
            var intentToJoinUri = Android.Net.Uri.Parse("https://castvideos.com/cast/join");
            System.Diagnostics.Debug.WriteLine(" URI Passed : " + intentToJoinUri);
            castContext.SessionManager.StartSession(intent);
            System.Diagnostics.Debug.WriteLine("URI Joined : " + intentToJoinUri);

       

        }

        public partial class CastSessionStartedListener : BackgroundEventListener
        {
            public override void BackgroundProcessEvent(Event p0)
            {
                CastSession castSession = castContext.SessionManager.CurrentCastSession;
                System.Diagnostics.Debug.WriteLine("TEST");

                Microsoft.MobCAT.MainThread.Run(() =>
                {
                    if (googleCastComponent.IsSessionAvailable && (castContext.SessionManager != null) && (castContext.SessionManager.CurrentCastSession != null))
                    {
                        CastSession castSession = castContext.SessionManager.CurrentCastSession;
                        System.Diagnostics.Debug.WriteLine("Connected!");
                    }
                });

            }
        }
    }

    public class CastStateListener : Java.Lang.Object, ICastStateListener
    {
        public void OnCastStateChanged(int newState)
        {
            Debug.WriteLine(newState);
        }
    }
}
