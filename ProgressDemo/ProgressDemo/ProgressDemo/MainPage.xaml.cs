using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgressDemo
{
    public partial class MainPage : ContentPage
    {
        public int CurrentTasks { get; set; }
        public MainPage()
        {
            InitializeComponent();
            gdMask00.IsVisible = false;
            gdMask10.IsVisible = false;
            gdMask01.IsVisible = false;
            gdMask11.IsVisible = false;
        }

        private async void btn00_Clicked(object sender, EventArgs e)
        {
            progbar00.Progress = 0;
            gdMask00.IsVisible = true;
            CurrentTasks++;
            UpdateBusy();
            for (int i = 0; i <= 150; i++)
            {
                progbar00.Progress = i / 150.0;
                await Task.Delay(100);
            }
            CurrentTasks--;
            UpdateBusy();
            gdMask00.IsVisible = false;
        }

        private void UpdateBusy()
        {
            if(CurrentTasks > 0)
            {
                activityIndicator.IsRunning = true;
            }
            else
            {
                activityIndicator.IsRunning = false;
            }
        }

        private async void btn10_Clicked(object sender, EventArgs e)
        {
            progbar10.Progress = 0;
            gdMask10.IsVisible = true;
            CurrentTasks++;
            UpdateBusy();
            for (int i = 0; i <= 100; i++)
            {
                progbar10.Progress = i / 100.0;
                await Task.Delay(100);
            }
            CurrentTasks--;
            UpdateBusy();
            gdMask10.IsVisible = false;
        }

        private async void btn01_Clicked(object sender, EventArgs e)
        {
            progbar01.Progress = 0;
            gdMask01.IsVisible = true;
            CurrentTasks++;
            UpdateBusy();
            for (int i = 0; i <= 120; i++)
            {
                progbar01.Progress = i / 120.0;
                await Task.Delay(100);
            }
            CurrentTasks--;
            UpdateBusy();
            gdMask01.IsVisible = false;
        }

        private async void btn11_Clicked(object sender, EventArgs e)
        {
            progbar11.Progress = 0;
            gdMask11.IsVisible = true;
            CurrentTasks++;
            UpdateBusy();
            for (int i = 0; i <= 80; i++)
            {
                progbar11.Progress = i / 80.0;
                await Task.Delay(100);
            }
            CurrentTasks--;
            UpdateBusy();
            gdMask11.IsVisible = false;
        }
    }
}
