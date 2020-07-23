using System;
using System.Diagnostics;
using Google.Cast;

namespace Brightcove.Forms.iOS
{
    public class ChromecastService : IChromecastService
    {
        public ChromecastService()
        {
        }

        public void SetupChromecast()
        {
            var discoveryCriteria = new DiscoveryCriteria("17F1E2B1");
            var castOptions = new CastOptions(discoveryCriteria);
            CastContext.SetSharedInstance(castOptions);
            CastContext.SharedInstance.UseDefaultExpandedMediaControls = true;
        }


        public void UpdateMiniPlayerVisibilty()
        {
            Debug.WriteLine("UPDATE FROM SERVICE, CODE SOON");
        }
    }
}
