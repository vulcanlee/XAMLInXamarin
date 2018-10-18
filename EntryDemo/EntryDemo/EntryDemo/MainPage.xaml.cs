using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EntryDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void entryEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelNotify.Text = $"輸入文字長度為 {entryEvent.Text.Length}";
            if(entryEvent.Text.Length<=10)
            {
                labelNotify.IsVisible = true;
            }
            else
            {
                labelNotify.IsVisible = false;
            }
        }

        private void entryEvent_Completed(object sender, EventArgs e)
        {
            if (entryEvent.Text.Length <= 10)
            {
                DisplayAlert("錯誤", "輸入文字長度必須大於10", "確定");
            }
        }

        private void btnEditor_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Page1());
        }

        private void entryEvent_Unfocused(object sender, FocusEventArgs e)
        {
            if (entryEvent.Text.Length <= 10)
            {
                DisplayAlert("錯誤 !!", "輸入文字長度必須大於10", "確定");
            }
        }
    }
}
