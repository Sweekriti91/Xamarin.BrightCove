using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Brightcove.Forms;
using Brightcove.Forms.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MiniPlayerCV), typeof(MiniPlayerRenderer))]
namespace Brightcove.Forms.Droid.Renderer
{
    public class MiniPlayerRenderer : ViewRenderer<MiniPlayerCV, global::Android.Views.View>
    {
        LinearLayout linearLayout;
        global::Android.Views.View view;
        Activity activity;
        //Android.Gms.Cast.Framework.Media.Widget.MiniControllerFragment

        public MiniPlayerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<MiniPlayerCV> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    //linearLayout = new LinearLayout(Context);
                    //miniPlayerController = new MiniControllerFragment();
                    //var test = miniPlayerController.UIMediaController;
                    //if (miniPlayerController != null)
                    //    linearLayout.AddView(miniPlayerController.View);

                    //linearLayout = (LinearLayout)FindViewById(Resource.Layout.miniplayerLayout);
                    ////var frgM = Control.Context.GetFragmentManager();
                    ////frgM.FindFragmentById(Resource.Id.castMiniController);
                    //if (linearLayout!= null)
                    //    SetNativeControl(linearLayout);


                    activity = this.Context as Activity;
                    view = activity.LayoutInflater.Inflate(Resource.Layout.miniPlayerLayout, this, false);
                    linearLayout = view.FindViewById<LinearLayout>(Resource.Layout.miniPlayerLayout);
                    //activity.SetContentView(view);
                    //AddView(view);
                    SetNativeControl(view);
                }
            }
        }
    }
}
