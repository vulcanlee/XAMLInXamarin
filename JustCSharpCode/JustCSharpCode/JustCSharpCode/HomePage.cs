using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JustCSharpCode
{
    // 這個類別將會成為與充滿整個螢幕頁面
    class HomePage : ContentPage
    {
        int index = 0;
        public HomePage()
        {
            // 建立一個文字標籤控制項
            Label label = new Label();
            // 建立一個按鈕控制項，並且設定該按鈕要顯示 確定 文字在按鈕上
            Button button = new Button()
            {
                Text = "確定"
            };
            // 設定當使用者點選這個按鈕之後，將會執行 Clicked 訂閱事件的委派方法
            button.Clicked += (s, e) =>
            {
                label.Text = $"點選按鈕次數 {++index}";
            };
            // 設定整個螢幕頁面會使用 StackLayout 版面配置來進行安排要顯示的內容
            this.Content = new StackLayout()
            {
                // 設定這個版面配置的運作屬性 Property
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                // 設定這個版面配置裡面，有顯示那些控制項內容
                Children =
                {
                    // 建立一個文字輸入盒控制項
                    new Entry()
                    {
                        Placeholder = "請輸入您的名字"
                    },
                    label,
                    button
                }
            };
        }
    }
}
