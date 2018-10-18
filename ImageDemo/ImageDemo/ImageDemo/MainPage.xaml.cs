using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLoadShareImage_Clicked(object sender, EventArgs e)
        {
            image.Source = ImageSource.FromResource("ImageDemo.sampleShare.jpg", typeof(MainPage).Assembly);
        }
    }
}
