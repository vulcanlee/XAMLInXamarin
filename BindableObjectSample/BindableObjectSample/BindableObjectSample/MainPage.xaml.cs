using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindableObjectSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PropertyChanging += DoPropertyChanging;
            PropertyChanged += DoPropertyChanged;
            BindingContextChanged += DoBindingContextChanged;

            BindingContext = new MainPageViewModel();
            label.PropertyChanged += DoPropertyChanged;
        }

        private void DoBindingContextChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"這個頁面的綁定內容 BindingContext 已經產生異動");
            Console.WriteLine($"現在 綁定內容 BindingContext 的屬性值屬於 {BindingContext.GetType().Name} 型別");
        }

        private void DoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"這個屬性 ==>{e.PropertyName} 的值，已經產生異動");
        }

        private void DoPropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            Console.WriteLine($"這個屬性 ==>{e.PropertyName} 的值，準備產生異動");
        }

        private void btnSetValue_Clicked(object sender, EventArgs e)
        {
            label.SetValue(CustomLabel.CustomTextProperty, "呼叫 SetValue 變更屬性值");
        }

        private void btnDirect_Clicked(object sender, EventArgs e)
        {
            label.CustomText = "直接變更屬性值";
        }

        private void btnViewModel_Clicked(object sender, EventArgs e)
        {
            var fooVM = this.BindingContext as MainPageViewModel;
            fooVM.Title = "透過 檢視模型 變更文字標籤文字內容";
        }
    }
}
