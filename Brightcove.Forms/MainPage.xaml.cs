using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.MobCAT;
using Xamarin.Forms;

namespace Brightcove.Forms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IChromecastService _castHelper = ServiceContainer.Resolve<IChromecastService>();

        public MainPage()
        {
            InitializeComponent();
            _castHelper.SetupChromecast();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PlayerPage());
        }
    }
}
