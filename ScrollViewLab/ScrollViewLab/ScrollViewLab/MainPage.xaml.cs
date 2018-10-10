using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScrollViewLab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGoLeft_Clicked(object sender, EventArgs e)
        {
            scrollview.ScrollToAsync(-150, 0, true);
        }

        private void btnGoRight_Clicked(object sender, EventArgs e)
        {
            scrollview.ScrollToAsync(150, 0, true);
        }

        private void btnGoLabel_Clicked(object sender, EventArgs e)
        {
            scrollview.ScrollToAsync(lblHor, ScrollToPosition.Center, true);
        }
    }
}
