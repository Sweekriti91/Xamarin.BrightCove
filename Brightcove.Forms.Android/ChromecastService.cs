using System;
using Android.Content;
using Brightcove.Forms.Droid.Renderer;
using Xamarin.Essentials;

namespace Brightcove.Forms.Droid
{
    public class ChromecastService : IChromecastService
    {
        public ChromecastService()
        {
        }

        public void OpenPlayerPage()
        {
            var intent = new Intent(Platform.CurrentActivity, typeof(PlayerActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            Platform.AppContext.StartActivity(intent);
        }

        public void SetupChromecast()
        {
            //TODO Add Setup
        }
    }   
}
