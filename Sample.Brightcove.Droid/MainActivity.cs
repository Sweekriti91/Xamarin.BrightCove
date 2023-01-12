using Android.App;
using Android.OS;
using Android.Runtime;
using Com.Brightcove.Player;
using Com.Brightcove.Player.Edge;
//using Com.Brightcove.Exoplayer;
using Com.Brightcove.Player.View;
using Com.Brightcove.Player.Model;
using Android.Views;
using Com.Brightcove.Player.Events;
using AndroidX.Fragment.App;
//using Android.Gms.Cast.Framework.Media.Widget;
using AndroidX.AppCompat.App;
//using Android.Gms.Cast;
using Xamarin.Essentials;
//using Com.Brightcove.Cast.Util;
using System.Linq;
using System.Collections.Generic;
using Android.Media;
//using MediaInfo = Android.Gms.Cast.MediaInfo;
using System;

namespace Sample.Brightcove.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BrightcovePlayer
    {
        static BrightcoveExoPlayerVideoView brightcoveVideoView;
        //Brightcove DRM Asset
        //static string policyKEY = "BCpkADawqM3zXLtsEM0nAyA_3o3TmZnG6bZTXFmjZ8X_rmFMqlpB78l0aiRELs7MWACf4mYN92qMOLMxfZN6Xr3cQ_0R3G2qBiho3X3Nc2yTv7DH4APQ-EimMJQ3crX0zc0mJMy9CtSqkmli";
        //static string accountID = "3303963094001";
        //string videoId = "4283173439001";

        //Non-DRM Asset
        // from sample app https://github.com/BrightcoveOS/android-player-samples/blob/master/brightcove-exoplayer/BasicSampleApp/src/main/res/values/strings.xml

        static string policyKEY = "BCpkADawqM1W-vUOMe6RSA3pA6Vw-VWUNn5rL0lzQabvrI63-VjS93gVUugDlmBpHIxP16X8TSe5LSKM415UHeMBmxl7pqcwVY_AZ4yKFwIpZPvXE34TpXEYYcmulxJQAOvHbv2dpfq-S_cm";
        static string accountID = "3636334163001";
        string videoId = "3637773814001";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            brightcoveVideoView = FindViewById<BrightcoveExoPlayerVideoView>(Resource.Id.brightcove_video_view);
            var eventEmitter = brightcoveVideoView.EventEmitter;
            Catalog catalog = new Catalog(eventEmitter, accountID, policyKEY);

            catalog.FindVideoByID(videoID: videoId, new VideoListenerR());


            //GoogleCastComponent googleCastComponent = new GoogleCastComponent(eventEmitter, this);
            //googleCastComponent.IsSessionAvailable;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //GoogleCastComponent.SetUpMediaRouteButton(this, menu);

            this.MenuInflater.Inflate(Resource.Menu.main, menu);

            return base.OnCreateOptionsMenu(menu); ;
        }

        public partial class VideoListenerR : VideoListener
        {
            public override void OnVideo(Video video)
            {
                brightcoveVideoView.Add(video);
                brightcoveVideoView.Start();
                //SetupCast(video);
            }

            //public override void OnError(string error)
            //{
            //    throw new Java.Lang.RuntimeException(error);
            //}

            //public void SetupCast(Video video)
            //{
            //    var eventEmitter = brightcoveVideoView.EventEmitter;

            //    Source source = findCastableSource(video);

            //    GoogleCastComponent googleCastComponent = new GoogleCastComponent(eventEmitter, Platform.AppContext);
            //    MediaInfo mediaInfo = CastMediaUtil.ToMediaInfo(video, source, null, null);
            //    googleCastComponent.LoadMediaInfo(mediaInfo);

            //    //You can check if there is a session available
            //    //googleCastComponent.isSessionAvailable();
            //}
        }

        //public static Source findCastableSource(Video video)
        //{
        //    Source savedDashSource = null;

        //    if (video.SourceCollections.Count != 0
        //            && video.SourceCollections.ContainsKey(DeliveryType.Dash)
        //            && video.SourceCollections.Values.Where(c => c.DeliveryType == DeliveryType.Dash) != null) 
        //    {
        //        var dashSourceCollections = video.SourceCollections.Values.Where(c => c.DeliveryType == DeliveryType.Dash);
        //        List<Source> dashSource = new List<Source>();
        //        foreach(var d in dashSourceCollections)
        //        {
        //            var item = d.Sources.Where(a => a.Url.Contains("dash")).ToList<Source>();
        //            dashSource = item;
        //        }
                
        //        foreach (var src in dashSource)
        //        {
        //            savedDashSource = src;

        //            if (src.Url.Contains("ac-3_avc1_ec-3_mp4a"))
        //            {
        //                Console.WriteLine("SOURCE :: " + src);
        //                return src;
        //            }
        //        }

        //        Console.WriteLine("SOURCE :: " + savedDashSource);
        //        return savedDashSource;
        //    }
        //    return null;
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}