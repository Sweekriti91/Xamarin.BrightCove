using Android.App;
using Android.OS;
using Android.Runtime;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.View;
using Com.Brightcove.Player.Model;

namespace Sample.Brightcove.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BrightcovePlayer
    {
        static BrightcoveExoPlayerVideoView  brightcoveVideoView;

        static string policyKEY = "BCpkADawqM3zXLtsEM0nAyA_3o3TmZnG6bZTXFmjZ8X_rmFMqlpB78l0aiRELs7MWACf4mYN92qMOLMxfZN6Xr3cQ_0R3G2qBiho3X3Nc2yTv7DH4APQ-EimMJQ3crX0zc0mJMy9CtSqkmli";
        static string accountID = "3303963094001";
        string videoId = "4283173439001";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            brightcoveVideoView = FindViewById<BrightcoveExoPlayerVideoView>(Resource.Id.brightcove_video_view);
            Catalog catalog = new Catalog(brightcoveVideoView.EventEmitter, accountID, policyKEY);

            catalog.FindVideoByID(videoID: videoId, new VideoListenerR());
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
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}