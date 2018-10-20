using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TableViewDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGenQRCode_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("資訊", "啟用推播通知:"+
                scPush.On + Environment.NewLine+
                "姓名:" +
                ecName.Text, "確定");
        }
    }
}
