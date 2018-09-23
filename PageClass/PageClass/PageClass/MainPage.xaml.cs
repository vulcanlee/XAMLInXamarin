using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageClass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void btnChangeNavigation_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }

        private void ToolbarItemNextPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }

        private async void btnIsBusy_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            await Task.Delay(3000);
            this.IsBusy = false;
        }
    }
}
