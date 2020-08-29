using System;
using System.Diagnostics;
using Brightcove.Forms;
using Brightcove.Forms.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Google.Cast;
using UIKit;
using CoreGraphics;
using Microsoft.MobCAT; 

[assembly: ExportRenderer(typeof(MiniPlayerCV), typeof(MiniPlayerRenderer))]
namespace Brightcove.Forms.iOS.Renderers
{
    public class MiniPlayerRenderer : ViewRenderer<MiniPlayerCV, UIView>
    {
        IChromecastService _castHelper = ServiceContainer.Resolve<IChromecastService>();
        UIMiniMediaControlsViewController miniMediaControlsViewController;
        UIView miniMediaControlsContainerView;

        protected override void OnElementChanged(ElementChangedEventArgs<MiniPlayerCV> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var castContext = CastContext.SharedInstance;
                    miniMediaControlsViewController = castContext.CreateMiniMediaControlsViewController();
                    miniMediaControlsViewController.Delegate = new XamGoogleCastMiniControllerDelegate(this);
                    miniMediaControlsContainerView = new UIView();
                    miniMediaControlsContainerView.Frame = new CGRect(0, 0, 400, 45);
                    miniMediaControlsViewController.View.Frame = miniMediaControlsContainerView.Bounds;
                    miniMediaControlsContainerView.AddSubview(miniMediaControlsViewController.View);
                    UpdateControlBarsVisibility();
                    SetNativeControl(miniMediaControlsContainerView);
                }
            }
        }

        public class XamGoogleCastMiniControllerDelegate : UIMiniMediaControlsViewControllerDelegate
        {
            MiniPlayerRenderer playerRenderer;

            public XamGoogleCastMiniControllerDelegate(MiniPlayerRenderer pageR)
            {
                this.playerRenderer = pageR;
            }

            public override void ShouldAppear(UIMiniMediaControlsViewController miniMediaControlsViewController, bool shouldItAppear)
            {
                playerRenderer.UpdateControlBarsVisibility();
            }
        }

        public void UpdateControlBarsVisibility()
        {
            Debug.WriteLine("miniMediaControlsViewController Active : " + miniMediaControlsViewController.Active);
            if (miniMediaControlsViewController.Active)
            {
                Debug.WriteLine("TRUE YES MINI");
                miniMediaControlsContainerView.Frame = new CGRect(0, 0, 400, 55);
                miniMediaControlsContainerView.SetNeedsDisplay();
                miniMediaControlsContainerView.LayoutIfNeeded();
            }
            else
            {
                Debug.WriteLine("FALSE NO MINI");
                miniMediaControlsContainerView.Frame = new CGRect(0, 0, 400, 0);
                miniMediaControlsContainerView.SetNeedsDisplay();
                miniMediaControlsContainerView.LayoutIfNeeded();
            }

        }
    }
}
