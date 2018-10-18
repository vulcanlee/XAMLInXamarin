using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ButtonDemo
{
        public class MainPageViewModel : INotifyPropertyChanged
        {
            private string _CommandMessage = "";
            public string CommandMessage
            {
                get { return _CommandMessage; }
                set
                {
                    _CommandMessage = value;
                    OnPropertyChanged("CommandMessage");
                }
            }
            public ICommand ButtonCommand { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;

            public MainPageViewModel()
            {
                ButtonCommand = new Command(() =>
                {
                    CommandMessage = $"按鈕已經按下了 {DateTime.Now}";
                });
            }

            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    public partial class MainPage : ContentPage
    {
        Color backupColor;
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();

            backupColor = sw.OnColor;
        }

        private void swEnableColor_Toggled(object sender, ToggledEventArgs e)
        {
            if(swEnableColor.IsToggled == true)
            {
                sw.OnColor = Color.Gold;
            }
            else
            {
                sw.OnColor = backupColor;
            }
        }
    }
}
