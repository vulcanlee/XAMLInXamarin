using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDPageDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Init();
        }

        async Task Init()
        {
            for (int i = 0; i < 40; i++)
            {
                gd.Rotation = (i * 10) % 360;
                await Task.Delay(100);
            }

            App.Current.MainPage = new MDPage();
        }
    }
}
