using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ViewClass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            labelScreen.Text = $"螢幕真實畫素 W {Xamarin.Essentials.DeviceDisplay.ScreenMetrics.Width} x H {Xamarin.Essentials.DeviceDisplay.ScreenMetrics.Height}";
            labelScreenDensity.Text = $"螢幕縮放比 {Xamarin.Essentials.DeviceDisplay.ScreenMetrics.Density}";
        }
    }
}
