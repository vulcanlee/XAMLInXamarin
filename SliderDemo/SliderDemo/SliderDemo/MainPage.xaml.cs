using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SliderDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            boxview.Color = Color.FromRgba(sliderR.Value, sliderG.Value, sliderB.Value, sliderA.Value);
        }

        private void sliderA_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxview.Color = Color.FromRgba(sliderR.Value, sliderG.Value, sliderB.Value, sliderA.Value);
        }

        private void sliderR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxview.Color = Color.FromRgba(sliderR.Value, sliderG.Value, sliderB.Value, sliderA.Value);
        }

        private void sliderG_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxview.Color = Color.FromRgba(sliderR.Value, sliderG.Value, sliderB.Value, sliderA.Value);
        }

        private void sliderB_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            boxview.Color = Color.FromRgba(sliderR.Value, sliderG.Value, sliderB.Value, sliderA.Value);
        }
    }
}
