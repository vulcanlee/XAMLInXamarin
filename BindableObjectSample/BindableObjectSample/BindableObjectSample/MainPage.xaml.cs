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
            this.PropertyChanging += DoPropertyChanged;
            
        }

        private void DoPropertyChanged(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            Console.WriteLine($"==>{e.PropertyName}");
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

        //private void DoPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    Console.WriteLine($"==>{e.PropertyName}");
        //}

    }
}
