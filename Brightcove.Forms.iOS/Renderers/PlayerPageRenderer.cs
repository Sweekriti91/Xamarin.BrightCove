using System;
using Brightcove.Forms;
using Brightcove.Forms.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlayerPage), typeof(PlayerPageRenderer))]
namespace Brightcove.Forms.iOS.Renderers
{
    public class PlayerPageRenderer : PageRenderer
    {
        public PlayerPageRenderer()
        {
        }
    }
}
