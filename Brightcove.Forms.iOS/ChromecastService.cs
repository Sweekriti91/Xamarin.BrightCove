using System;
using System.Diagnostics;
using Google.Cast;
using Foundation;

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


        public void CastStateReport()
        {
            NSNotificationCenter aNotificationCenter = NSNotificationCenter.DefaultCenter;
            aNotificationCenter.AddObserver(this, new ObjCRuntime.Selector("castDidChangeState:"), CastContext.CastStateDidChangeNotification, CastContext.SharedInstance);

        }

        [Export("castDidChangeState:")]
        private void castDidChangeState(NSNotification obj)
        {
            switch (CastContext.SharedInstance.CastState)
            {
                case CastState.NoDevicesAvailable:
                    Console.WriteLine("Cast Status: No Devices Available");
                    break;
                case CastState.NotConnected:
                    Console.WriteLine("Cast Status: Not Connected");
                    break;
                case CastState.Connecting:
                    Console.WriteLine("Cast Status: Connecting");
                    break;
                case CastState.Connected:
                    Console.WriteLine("Cast Status: Connected");
                    break;
            }
        }
    }
}
