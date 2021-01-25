
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Cast.Framework;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Brightcove.Cast;
using Com.Brightcove.Player.View;
using Video = Com.Brightcove.Player.Model.Video;
using Debug = System.Diagnostics.Debug;
using MediaRouteButton = Android.Support.V7.App.MediaRouteButton;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.Events;

namespace Brightcove.Forms.Droid.Renderer
{
    [Activity(Label = "PlayerActivity", Theme = "@style/MyTheme.Player")]
    public class PlayerActivity : AppCompatActivity
    {

        global::Android.Views.View view;
        Activity activity;

       

        static BrightcoveExoPlayerVideoView brightcoveVideoView;
        static MediaRouteButton castButton;
        static GoogleCastComponent googleCastComponent;
        public static CastContext castContext;
        CastStateListener listenerCast;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            castContext = CastContext.SharedInstance;
            //listenerCast = new CastStateListener();
            //castContext.AddCastStateListener(listenerCast);


            SetContentView(Resource.Layout.activity_main);

            brightcoveVideoView = FindViewById<BrightcoveExoPlayerVideoView>(Resource.Id.brightcove_video_view);
            var eventEmitter = brightcoveVideoView.EventEmitter;
            Catalog catalog = new Catalog(eventEmitter, accountID, policyKEY);

            catalog.FindVideoByID(videoID: videoId, new VideoListenerR());


            //BACK BUTTON
            var backButton = FindViewById<Button>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;


            castButton = (MediaRouteButton)FindViewById(Resource.Id.media_route_button);
            CastButtonFactory.SetUpMediaRouteButton(ApplicationContext, castButton);

          
            SetupCast();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            brightcoveVideoView.StopPlayback();
            this.Finish();
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

            var eventEmitter = brightcoveVideoView.EventEmitter;
            CustomCastMediaManager customCastMediaManager = new CustomCastMediaManager(ApplicationContext, eventEmitter);
            googleCastComponent = new GoogleCastComponent(eventEmitter, ApplicationContext, customCastMediaManager);

            // listen for cast started and ended events
            eventEmitter.On(GoogleCastEventType.CastSessionStarted, new CastSessionStartedListener());

        }

        public partial class CastSessionStartedListener : BackgroundEventListener
        {
            public override void BackgroundProcessEvent(Event p0)
            {
                //CastSession castSession = castContext.SessionManager.CurrentCastSession;
                System.Diagnostics.Debug.WriteLine("TEST");

                //Microsoft.MobCAT.MainThread.Run(() =>
                //{
                //    if (googleCastComponent.IsSessionAvailable && (castContext.SessionManager != null) && (castContext.SessionManager.CurrentCastSession != null))
                //    {
                //        CastSession castSession = castContext.SessionManager.CurrentCastSession;
                //        System.Diagnostics.Debug.WriteLine("Connected!");
                //    }
                //});

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
}
