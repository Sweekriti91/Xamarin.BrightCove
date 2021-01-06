using System;
using Android.Content;
using Android.Gms.Cast.Framework;
using Android.Support.V7.App;
using Android.Widget;
using Brightcove.Forms;
using Brightcove.Forms.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCastButton), typeof(MyCastButtonRender))]
namespace Brightcove.Forms.Droid.Renderer
{
    public class MyCastButtonRender : ViewRenderer<MyCastButton, LinearLayout>
    {
        MediaRouteButton mediaRouteButton;
        LinearLayout linearLayout;

        public MyCastButtonRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<MyCastButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    mediaRouteButton = new MediaRouteButton(Context);
                    CastButtonFactory.SetUpMediaRouteButton(Context, mediaRouteButton);
                    linearLayout = new LinearLayout(Context);
                    linearLayout.AddView(mediaRouteButton);

                    SetNativeControl(linearLayout);
                }
            }
        }

    }
}
