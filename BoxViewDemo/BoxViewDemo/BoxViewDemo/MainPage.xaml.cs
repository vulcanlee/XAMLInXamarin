using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoxViewDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            boxViewMask.IsVisible = false;
            boxviewCurrent.HeightRequest = 0;
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            boxViewMask.IsVisible = true;
            int fooCC = 0;
            for (int i = 0; i < 100; i++)
            {
                if (i <= 49)
                {
                    boxviewCurrent.HeightRequest = 200.0 * (i / 49.0);
                }
                else
                {
                    boxviewCurrent.HeightRequest = 200.0 * ((99-i) / 49.0);
                }
                await Task.Delay(100);
            }
            boxViewMask.IsVisible = false;
            boxviewCurrent.HeightRequest = 0;
        }
    }
}
