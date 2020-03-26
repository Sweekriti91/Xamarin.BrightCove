using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.View;

using Com.Brightcove.Exoplayer;

namespace Sample.Brightcove.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BrightcovePlayer
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //BrightcoveVideoView = FindViewById<>
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            // When extending the BrightcovePlayer, we must assign the brightcoveVideoView before
            // entering the superclass. This allows for some stock video player lifecycle
            // management.  Establish the video object and use it's event emitter to get important
            // notifications and to control logging.
            //native code below, fix
            // brightcoveVideoView = (BrightcoveExoPlayerVideoView) findViewById(R.id.brightcove_video_view);

            BrightcoveVideoView.FindViewById(Resource.Id.brightcove_video_view);
            //BaseVideoView baseVideoView = new BrightcoveVideoView(context: ApplicationContext);
            //baseVideoView = (BrightcoveVideoView)FindViewById(Resource.Id.brightcove_video_view);
            //EventEmitter eventEmitter =
            //Catalog catalog = new Catalog(baseVideoV, "3303963094001", "BCpkADawqM3zXLtsEM0nAyA_3o3TmZnG6bZTXFmjZ8X_rmFMqlpB78l0aiRELs7MWACf4mYN92qMOLMxfZN6Xr3cQ_0R3G2qBiho3X3Nc2yTv7DH4APQ-EimMJQ3crX0zc0mJMy9CtSqkmli");

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}