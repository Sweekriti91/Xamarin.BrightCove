using System;
using System.Diagnostics;
using Brightcove.Forms;
using Brightcove.Forms.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Google.Cast;
using UIKit;

[assembly: ExportRenderer(typeof(MiniPlayerCV), typeof(MiniPlayerRenderer))]
namespace Brightcove.Forms.iOS.Renderers
{
    public class MiniPlayerRenderer : ViewRenderer<MiniPlayerCV, UIView>
    {
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
                    miniMediaControlsViewController.Delegate = new XamGoogleCastMiniControllerDelegate();
                    miniMediaControlsContainerView = new UIView();
                    miniMediaControlsViewController.View.Frame = miniMediaControlsContainerView.Bounds;
                    miniMediaControlsContainerView.AddSubview(miniMediaControlsViewController.View);
                    SetNativeControl(miniMediaControlsContainerView);
                }
            }
        }

        public class XamGoogleCastMiniControllerDelegate : UIMiniMediaControlsViewControllerDelegate
        {

            public XamGoogleCastMiniControllerDelegate()
            {
            }

            public override void ShouldAppear(UIMiniMediaControlsViewController miniMediaControlsViewController, bool shouldItAppear)
            {
                //pageRenderer.UpdateControlBarsVisibility();
                //TODO Connect service to toggle visibility
                UpdateControlBarsVisibility();
            }
        }

        public void UpdateControlBarsVisibility()
        {
            Debug.WriteLine("miniMediaControlsViewController Active : " + miniMediaControlsViewController.Active);
            if (miniMediaControlsViewController.Active)
            {
                miniMediaControlsViewController.View.Hidden = false;
                //View.BringSubviewToFront(miniMediaControlsContainerView);
            }
            else
                miniMediaControlsViewController.View.Hidden = true;

        }

        //public void InstallViewController(UIMiniMediaControlsViewController viewController, UIView containerView)
        //{
        //    if (viewController != null)
        //    {
        //        this.ViewController.AddChildViewController(viewController);
        //        viewController.View.Frame = containerView.Bounds;
        //        containerView.AddSubview(viewController.View);
        //        viewController.DidMoveToParentViewController(this);
        //    }
        //}


    }
}
