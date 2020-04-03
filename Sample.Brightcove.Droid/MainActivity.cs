using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Com.Brightcove.Player.Edge;
using Com.Brightcove.Player.View;

using Com.Brightcove.Player.Model;

namespace Sample.Brightcove.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BrightcovePlayer
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var brightcoveVideoView = FindViewById<BrightcoveVideoView>(Resource.Id.brightcove_video_view);
            var catalog = new Catalog(brightcoveVideoView.EventEmitter, "3303963094001", "BCpkADawqM3zXLtsEM0nAyA_3o3TmZnG6bZTXFmjZ8X_rmFMqlpB78l0aiRELs7MWACf4mYN92qMOLMxfZN6Xr3cQ_0R3G2qBiho3X3Nc2yTv7DH4APQ-EimMJQ3crX0zc0mJMy9CtSqkmli");

            catalog.FindVideoByID(videoID: "4283173439001", new VideoListener()
            {

            });
            //brightcoveVideoView.Add()


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}