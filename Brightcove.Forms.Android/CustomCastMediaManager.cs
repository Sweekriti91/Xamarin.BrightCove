using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android.Content;
using Android.Gms.Cast;
using Android.Gms.Cast.Framework;
using Com.Brightcove.Cast.Controller;
using Com.Brightcove.Cast.Util;
using Com.Brightcove.Player.Events;
using Com.Brightcove.Player.Model;
using Newtonsoft.Json;
using Org.Json;

namespace Brightcove.Forms.Droid
{
    public class CustomCastMediaManager : BrightcoveCastMediaManager
    {
        public static Source castableSource;
        public static Video currentVideo;
        public Context currentContext;
        public string videoKey;


        public CustomCastMediaManager(Context context, IEventEmitter eventEmitter) : base(context, eventEmitter)
        {
            this.videoKey = videoKey;
            this.currentContext = context;
            eventEmitter.On(EventType.SetSource, new CCSetSourceListener());
        }


        public partial class CCSetSourceListener : BackgroundEventListener
        {
            public override void BackgroundProcessEvent(Event p0)
            {
                //Or just pass video as paramter from player activity
                currentVideo = (Video)p0.Properties["video"];
                if (currentVideo != null)
                {
                    castableSource = FindCastableSource(currentVideo);
                }
                Debug.WriteLine("CAST : cast controller video and source set");
            }
        }

        // override addMediaInfo to use our createMediaInfo logic
        //protected override void AddMediaInfo()
        protected override void AddMediaInfo()
        {
            //base.AddMediaInfo();

            if (this.IsSessionAvailable)
            {
                MediaInfo mediaInfo = CreateMediaInfo();
                if (mediaInfo != null)
                {
                    AddMediaInfo(mediaInfo);
                }
                else
                {
                    Debug.WriteLine("CAST : Media Queue Item is null");
                }
            }
        }

        // override loadMediaInfo to use our createMediaInfo logic
        protected override void LoadMediaInfo()
        {
            //base.LoadMediaInfo();
            if (this.IsSessionAvailable)
            {
                MediaInfo mediaInfo = this.CreateMediaInfo();
                if (mediaInfo != null)
                {
                    this.UpdateBrightcoveMediaController(true);
                    Debug.WriteLine("CAST : Loading Media Info wth the following structure : " + mediaInfo.ToJson());
                    LoadMediaInfo(mediaInfo);
                }
                else
                {
                    Debug.WriteLine("CAST : Media Queue Item is Null");
                }
            }
        }

        /**
         * this function creates a MediaInfo object from video source and adds the required custom data for licenseHeaders
         *
         * @return MediaInfo object
         */
        public MediaInfo CreateMediaInfo()
        {
            MediaInfo mediaInfo = null;

            if (currentVideo != null && castableSource != null)
            {
                MediaMetadata metadata = new MediaMetadata();
                metadata.PutString(MediaMetadata.KeySubtitle, currentVideo.Description);
                metadata.PutString(MediaMetadata.KeyTitle, currentVideo.Name);
               
                mediaInfo = CastMediaUtil.ToMediaInfo(currentVideo, castableSource, metadata, null);
                Debug.WriteLine("CAST : Created mediainfo with id == " + mediaInfo.ContentId);
            }

            return mediaInfo;
        }

       
        public static Source FindCastableSource(Video video)
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
                    var item = d.Sources.Where(a => a.Url.Contains("dash")).ToList();
                    dashSource = item;
                }

                foreach (var src in dashSource)
                {
                    savedDashSource = src;

                    //check for 5.1
                    if (src.Url.Contains("ac-3_avc1_ec-3_mp4a"))
                    {
                        Console.WriteLine("SOURCE :: " + src);
                        return src;
                    }

                    //check for stereo
                    if (src.Url.Contains("avc1_mp4a"))
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
