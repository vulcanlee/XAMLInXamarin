using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PopupDialog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnDisplayAlert_Clicked(object sender, EventArgs e)
        {
            bool result = await this.DisplayAlert("警告", "您確定要開始進行這個工作嗎？", "是的，我願意", "不，要取消");
            label.Text = $"[DisplayAlert] 您的選擇結果是 {result}";
        }

        private async void btnDisplayActionSheet_Clicked(object sender, EventArgs e)
        {
            string result = await this.DisplayActionSheet("請選擇您的需求", "取消", null, "C#", "XAML", "MVVM", "Prism", "C# Async");
            label.Text = $"[DisplayActionSheet] 您的選擇結果是 {result}";
        }
    }
}
