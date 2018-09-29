using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MDPageDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Console.WriteLine($"MainPage 建構函式使用的 執行緒 {Thread.CurrentThread.ManagedThreadId}");
            Init();
            Console.WriteLine($"MainPage 建構函式準備結束執行");
        }

        async Task Init()
        {
            Console.WriteLine($"Init 進入點的 執行緒 {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 40; i++)
            {
                gd.Rotation = (i * 10) % 360;
                await Task.Delay(100);
            }
            Console.WriteLine($"Init 準備離開 執行緒 {Thread.CurrentThread.ManagedThreadId}");

            App.Current.MainPage = new MDPage();
        }
    }
}
