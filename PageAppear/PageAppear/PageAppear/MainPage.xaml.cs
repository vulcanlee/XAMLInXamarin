using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageAppear
{
    public class GlobalClass : INotifyPropertyChanged
    {
        // Singleton
        public static GlobalClass Current = new GlobalClass();

        private GlobalClass()
        {

        }

        private string _MyProperty = $"開始{Environment.NewLine}";

        public string MyProperty
        {
            get { return _MyProperty; }
            set
            {
                _MyProperty = value;
                OnPropertyChanged("MyProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.SizeChanged += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"MainPage 觸發 SizeChanged W:{Width} x H:{Height} {Environment.NewLine}";
            };
            this.Appearing += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"MainPage 觸發 Appearing {Environment.NewLine}";
            };
            this.Disappearing += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"MainPage 觸發 Disappearing {Environment.NewLine}";
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GlobalClass.Current.MyProperty += $"MainPage 執行 OnAppearing{Environment.NewLine}";
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GlobalClass.Current.MyProperty += $"MainPage 執行 OnDisappearing {Environment.NewLine}";
        }

        private void btnPopup_Clicked(object sender, EventArgs e)
        {
            GlobalClass.Current.MyProperty += $"顯示對話窗 {Environment.NewLine}";
            DisplayAlert("資訊", "現在對話窗已經顯示在螢幕最前面了", "確定");
        }

        private void btnNavigateNewPage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NewPage());
        }

    }
}
