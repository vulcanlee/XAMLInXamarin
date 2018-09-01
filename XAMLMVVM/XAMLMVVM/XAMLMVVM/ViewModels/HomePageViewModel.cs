using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XAMLMVVM.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        int index = 0;

        #region 實作 INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 發出 INotifyPropertyChanged 事件，通知畫面要更新指定頁面中綁定的屬性 Attribute，使用 ViewModel 內的指定屬性 Property 來更新
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 用於綁定到螢幕上的 Label.Text 屬性 Attribute 上，這裡將用於資料綁定
        private string _ClickedButtonMessage;

        public string ClickedButtonMessage
        {
            get { return _ClickedButtonMessage; }
            set { _ClickedButtonMessage = value; OnPropertyChanged(); }
        }
        #endregion

        // 綁定按鈕中的 Command 屬性 Attribute，這裡將用於命令綁定
        public ICommand ButtonTapCommand { get; set; }

        public HomePageViewModel()
        {
            ButtonTapCommand = new Command(() =>
            {
                // 使用者點擊按鈕之後，將會執行此命令的委派方法
                ClickedButtonMessage = $"點選按鈕次數 {++index}";
            });
        }
    }
}
