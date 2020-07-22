using System;
using Brightcove.Forms;
using Brightcove.Forms.iOS.Renderers;
using CoreGraphics;
using Google.Cast;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Google.Cast;

[assembly: ExportRenderer(typeof(MyCastButton), typeof(MyCastButtonRenderer))]
namespace Brightcove.Forms.iOS.Renderers
{
    public class MyCastButtonRenderer : ViewRenderer<MyCastButton,UICastButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MyCastButton> e)
        {
            UICastButton castButton;

            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                if (Control == null)
                {
                    castButton = new UICastButton();
                    SetNativeControl(castButton);
                }
            }
        }
    }
}
