using System;
using Xamarin.Forms;
using Brightcove.Forms;
using Brightcove.Forms.Droid.Renderer;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Content;
using Android.Views;
using Com.Brightcove.Player.View;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.Model;
using Com.Brightcove.Cast;
using Android.Gms.Cast;
using Xamarin.Essentials;
using Com.Brightcove.Cast.Util;
using System.Collections.Generic;
using System.Linq;
using Android.Gms.Cast.Framework;
using Android.Support.V7.App;
using Android.App;
using MediaRouteButton = Android.Support.V7.App.MediaRouteButton;

[assembly: ExportRenderer(typeof(PlayerPage), typeof(PlayerPageRenderer))]
namespace Brightcove.Forms.Droid.Renderer
{
    public class PlayerPageRenderer : PageRenderer
    {
        global::Android.Views.View view;
        Activity activity;

        static string policyKEY = "BCpkADawqM3YRyTQ4hZzmqTk-Oegl3lHc_iLPz29j-aHgdZy0hLaKVj-TlITBvYppMXWpz4mGh60AgWogCIF42vzi1lkj9vgAjYNjAwjd8xeW-JwTb1yI4XPq0mGXaXx4KY-Nu7MwFX0QsQi";
        static string accountID = "6056665239001";
        string videoId = "6169021538001";

        static BrightcoveExoPlayerVideoView brightcoveVideoView;
        static MediaRouteButton castButton;
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



            brightcoveVideoView = view.FindViewById<BrightcoveExoPlayerVideoView>(Resource.Id.brightcove_video_view);
            var eventEmitter = brightcoveVideoView.EventEmitter;
            Catalog catalog = new Catalog(eventEmitter, accountID, policyKEY);

            catalog.FindVideoByID(videoID: videoId, new VideoListenerR());


            castButton = (MediaRouteButton)view.FindViewById(Resource.Id.media_route_button);
            CastButtonFactory.SetUpMediaRouteButton(Context, castButton);

            var test = Context;
            var test2 = Xamarin.Essentials.Platform.CurrentActivity;
        }

        public partial class VideoListenerR : VideoListener
        {
            public override void OnVideo(Video video)
            {
                brightcoveVideoView.Add(video);
                brightcoveVideoView.Start();
                SetupCast(video);
            }

            public override void OnError(string error)
            {
                throw new Java.Lang.RuntimeException(error);
            }

            public void SetupCast(Video video)
            {
                var eventEmitter = brightcoveVideoView.EventEmitter;

                Source source = findCastableSource(video);

                GoogleCastComponent googleCastComponent = new GoogleCastComponent(eventEmitter, Xamarin.Essentials.Platform.CurrentActivity);

                MediaInfo mediaInfo = CastMediaUtil.ToMediaInfo(video, source, null, null);
                googleCastComponent.LoadMediaInfo(mediaInfo);

                //You can check if there is a session available
                //googleCastComponent.isSessionAvailable();
            }
        }

        public static Source findCastableSource(Video video)
        {
            Source savedDashSource = null;

            if (video.SourceCollections.Count != 0
                    && video.SourceCollections.ContainsKey(DeliveryType.Dash)
                    && video.SourceCollections.Values.Where(c => c.DeliveryType == DeliveryType.Dash) != null)
            {
                var dashSourceCollections = video.SourceCollections.Values.Where(c => c.DeliveryType == DeliveryType.Dash);
                List<Source> dashSource = new List<Source>();
                foreach (var d in dashSourceCollections)
                {
                    var item = d.Sources.Where(a => a.Url.Contains("dash")).ToList<Source>();
                    dashSource = item;
                }

                foreach (var src in dashSource)
                {
                    savedDashSource = src;

                    if (src.Url.Contains("ac-3_avc1_ec-3_mp4a"))
                    {
                        Console.WriteLine("SOURCE :: " + src);
                        return src;
                    }
                }

                Console.WriteLine("SOURCE :: " + savedDashSource);
                return savedDashSource;
            }
            return null;
        }
    }
}
