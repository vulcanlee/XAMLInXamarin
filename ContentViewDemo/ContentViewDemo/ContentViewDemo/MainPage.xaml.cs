using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContentViewDemo
{
    public class MyEntryViewModel : INotifyPropertyChanged
    {
        private string _Title = "";

        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _EntryHint = "";

        public string EntryHint
        {
            get { return _EntryHint; }
            set
            {
                _EntryHint = value;
                OnPropertyChanged(nameof(EntryHint));
            }
        }

        private string _Input = "";

        public string Input
        {
            get { return _Input; }
            set
            {
                _Input = value;
                OnPropertyChanged(nameof(Input));
            }
        }

        private bool _ShowTitle = true;

        public bool ShowTitle
        {
            get { return _ShowTitle; }
            set
            {
                _ShowTitle = value;
                OnPropertyChanged(nameof(ShowTitle));
            }
        }

        public MyEntryViewModel()
        {
            ShowTitle = true;
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
        public MyEntryViewModel Account { get; set; }
        public MyEntryViewModel Password { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Account = new MyEntryViewModel()
            {
                Title = "帳號",
                EntryHint = "請輸入電子郵件帳號",
                Input = "",
                ShowTitle = false
            };

            Password = new MyEntryViewModel()
            {
                Title = "密碼",
                EntryHint = "請輸入登入使用的密碼",
                Input = "",
                ShowTitle = false
            };

            BindingContext = this;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var result = $"登入帳號 {Account.Input}"+
                $"登入密碼 {Password.Input}";

            DisplayAlert("通知", result, "我知道了");
        }
    }
}
