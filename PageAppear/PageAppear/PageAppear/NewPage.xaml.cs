using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PageAppear
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{
		public NewPage ()
		{
			InitializeComponent ();

            this.SizeChanged += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"NewPage 觸發 SizeChanged W:{Width} x H:{Height} {Environment.NewLine}";
            };
            this.Appearing += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"NewPage 觸發 Appearing {Environment.NewLine}";
            };
            this.Disappearing += (s, e) =>
            {
                GlobalClass.Current.MyProperty += $"NewPage 觸發 Disappearing {Environment.NewLine}";
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GlobalClass.Current.MyProperty += $"NewPage 執行 OnAppearing{Environment.NewLine}";
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GlobalClass.Current.MyProperty += $"NewPage 執行 OnDisappearing {Environment.NewLine}";
        }
    }
}